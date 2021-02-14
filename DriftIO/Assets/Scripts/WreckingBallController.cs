using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class WreckingBallController : MonoBehaviour
{
    public Transform TargetTransform;
    public Transform CarTransform;

    public float animationTime;
    private float _currentAnimationTime;

    private  float initialZOffset;
    private Rigidbody rb;
    private SpringJoint joint;
    private float springConst;

    public bool animationEnabled;

    private TrailRenderer trail;

    void Start()
    {
        //transform.position = TargetTransform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        joint = GetComponent<SpringJoint>();
        springConst = joint.spring;
        trail = GetComponentInChildren<TrailRenderer>();
        trail.emitting = false;
    }

    void Update()
    {
        if(animationEnabled)
        {
            if(_currentAnimationTime == 0)
            {
                joint.spring = 0;
                trail.emitting = true;
            }

            if (_currentAnimationTime < animationTime)
            {
                transform.RotateAround(CarTransform.position, Vector3.up, 720 * Time.deltaTime);
                _currentAnimationTime += Time.deltaTime;
            }
            else
            {
                animationEnabled = false;
                _currentAnimationTime = 0;
                joint.spring = springConst; 
                trail.emitting = false;
            }
        }
    }

    public void DisableOnLose()
    {
        rb.useGravity = true;
        GetComponent<Collider>().enabled = false;
        joint.spring = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.transform.Equals(CarTransform))
        {
            if(collision.transform.CompareTag("Player"))
            {
                collision.transform.parent.GetComponent<PlayerController>().Impact(collision.impulse.normalized);                
            }
        }
    }
}
