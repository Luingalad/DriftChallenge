using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxController : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.IsSleeping())
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.GetComponent<PlayerController>().onDropBox();
            Destroy(gameObject);
        }
    }
}
