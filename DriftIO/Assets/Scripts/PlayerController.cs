using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform WreckingBall;
    public Transform PlayerModel;
    
    private InputController _inputController;
    private GameController _gameController;

    private bool _isAlive = true;

    public bool isPlayer;

    void Start()
    {
        _inputController = GetComponent<InputController>();
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {

        //PlayerModel.position = Vector3.Lerp(PlayerModel.position, inputController.InputTarget, Time.deltaTime * 5f);

        Ray ray = new Ray(PlayerModel.position + Vector3.up , Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 40) && _isAlive)
        {
            if (hit.transform.CompareTag("Water"))
            {
                _inputController.enable = false;
                PlayerModel.GetComponent<Rigidbody>().isKinematic = false;
                PlayerModel.GetComponent<Collider>().enabled = false;
                WreckingBall.GetComponent<WreckingBallController>().DisableOnLose();
                _isAlive = false;
            }
        }        

        if(!_isAlive)
        {
            _gameController.PlayerDead(PlayerModel.gameObject, isPlayer);
        }

    }

    public void onDropBox()
    {
        WreckingBall.GetComponent<WreckingBallController>().animationEnabled = true;
    }

    public void Impact(Vector3 normal)
    {
        Vector3 direction = new Vector3(-normal.x*2, 10, -normal.z*2);
        StopAllCoroutines();
        StartCoroutine(ImpactJump(direction));
        Debug.Log("Impact " + direction);  

    }

    private IEnumerator ImpactJump(Vector3 direction)
    {
        _inputController.enable = false;
        var target = direction + PlayerModel.position;

        while (Vector3.Distance(PlayerModel.position, target) > 0.5f)//rising
        {
            PlayerModel.position = Vector3.Lerp(PlayerModel.position, target, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }

        direction = new Vector3(direction.x, -direction.y, direction.z);
        target = PlayerModel.position + direction;

        while(Vector3.Distance(PlayerModel.position, target) > 0.5f)//falling
        {
            PlayerModel.position = Vector3.Lerp(PlayerModel.position, target, Time.deltaTime * 2f);
            yield return new WaitForEndOfFrame();
        }

        PlayerModel.position = new Vector3(PlayerModel.position.x, 0, PlayerModel.position.z);
        _inputController.enable = true;
    }
}
