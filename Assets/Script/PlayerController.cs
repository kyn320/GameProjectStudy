using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float jumpPower, rotateDegree;

    Rigidbody ri;
    Transform tr;

    float degree = 0;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }


    void Jump()
    {
        ri.velocity = Vector3.zero;
        ri.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        ri.AddTorque(Vector3.up * rotateDegree, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.AddScore();
        other.gameObject.SetActive(false);
    }

}

