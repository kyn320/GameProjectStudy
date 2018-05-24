using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotater : MonoBehaviour
{
    [HideInInspector]
    public RingBehaviour ring;

    Transform tr;

    public float degree = 0f;
    public float lerpSpeed = 10f;
    public float lerpTime = 0;

    [Space]

    public bool isLoop = false;
    public float originDegree = 0;
    public float loopAddDegree = 0;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        ring = GetComponent<RingBehaviour>();
        originDegree = degree;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public void RandomData()
    {
        loopAddDegree = Random.Range(10f,30f);

        isLoop = true;
        lerpSpeed = Random.Range(0.1f, 1f);
    }


    public void Rotate()
    {
        if (isLoop && lerpTime >= 1)
        {
            lerpTime = 0;

            degree += loopAddDegree;
            degree %= 360f;
        }

        lerpTime += Time.deltaTime * lerpSpeed;
        tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime * lerpTime);
    }

}
