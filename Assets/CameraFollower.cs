using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public Vector3 margin;

    Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        tr.position = Vector3.Lerp(tr.position, target.position + margin, Time.deltaTime * 10f);
    }


}
