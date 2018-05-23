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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime * 10f);
    }

    void Jump()
    {
        ri.velocity = Vector3.zero;
        ri.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        degree += rotateDegree;

        //ri.AddTorque(Vector3.up * rotateDegree, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("Is Touched! GameOver");
    }

}

