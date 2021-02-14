using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : InputController
{
    private float? oldX;
    public override void Update()
    {
        float angel = 0;
        if(Input.GetMouseButton(0))
        {
            //InputResult(Input.mousePosition);
            if (oldX.HasValue)
            {
                angel += CalculateAngle(Input.mousePosition.x - oldX.Value);
                
            }
            
        }
        oldX = Input.mousePosition.x;
        if (Input.touchCount > 0)
        {
            //InputResult(Input.GetTouch(0).position);
            angel = CalculateAngle(Input.GetTouch(0).deltaPosition.x);
            Debug.Log(angel);
        }
        
        PlayerModel.Rotate(new Vector3(0, angel, 0) * Time.deltaTime);
    }

    private float CalculateAngle(float deltaX)
    {
        return Mathf.Clamp(deltaX * InputMultiplier *InputSensitivity, -600, 600);
    }

    //Yorum satırı olan kodları mekaniği yanlış anladığım için yazdım. Ama silmek istemedim.\\
    /*
    private void InputResult(Vector3 inputScreenPos)
    {
        var ray = Camera.main.ScreenPointToRay(inputScreenPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var result = GetArenaPos(hit);

            if (result.HasValue)
            {
                deltaInputTarget = result.Value - InputTarget;
                InputTarget = result.Value;
            }
        }
    }

    private Vector3? GetArenaPos(RaycastHit hit)
    {
        if(hit.transform.CompareTag("Arena"))
        {
            if(hit.normal == Vector3.up)
            return hit.point;
        }
        return null;
    }
    */
}
