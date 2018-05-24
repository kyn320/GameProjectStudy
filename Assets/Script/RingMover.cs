using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMover : MonoBehaviour
{
    [HideInInspector]
    public RingBehaviour ring;

    Transform tr;

    public Vector3 position;
    public float lerpSpeed = 10f;
    public float lerpTime = 0;

    [Space]

    public bool isLoop = false;
    public Vector3 originPos;
    public Vector3[] LoopDir;
    [SerializeField]
    int loopCnt = 0;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        ring = GetComponent<RingBehaviour>();
        originPos = position = tr.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void RandomData()
    {
        LoopDir = new Vector3[2];

        int randX = Random.Range(2,11);

        originPos = tr.position;
        LoopDir[0] = LoopDir[1] = originPos;

        LoopDir[0].x = -randX;
        LoopDir[1].x = randX;

        isLoop = true;
        lerpSpeed = Random.Range(0.1f, 0.7f);
    }



    public void Move()
    {
        if (isLoop && LoopDir.Length > 0 && lerpTime >= 1)
        {
            lerpTime = 0;

            ++loopCnt;
            loopCnt = loopCnt % LoopDir.Length;

            position = LoopDir[loopCnt];
        }

        lerpTime += Time.deltaTime * lerpSpeed;
        tr.position = Vector3.Lerp(tr.position, position, lerpTime);
    }



}
