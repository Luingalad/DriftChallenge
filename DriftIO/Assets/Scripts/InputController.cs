using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector3 InputTarget;
    public Vector3 deltaInputTarget;

    public float InputSensitivity;
        
    public float InputMultiplier = 0.01f;

    public Transform PlayerModel;

    public bool enable;
    private void Start()
    {
        PlayerModel = GetComponent<PlayerController>().PlayerModel;
        enable = true;
    }

    public virtual void Update()
    {

    }

    private void LateUpdate()
    {       
        if(enable) PlayerModel.Translate(Vector3.forward * Time.deltaTime * 4f);
    }
}
