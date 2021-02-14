using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraTarget;
    public Vector3 CamOffset;
      
    private void LateUpdate()
    {
        var pos = CameraTarget.position + CamOffset;
        transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, transform.position.y, pos.z), Time.deltaTime * 6f);
    }
}
