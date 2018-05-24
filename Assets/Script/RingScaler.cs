using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScaler : MonoBehaviour
{
    [HideInInspector]
    public RingBehaviour ring;

    Transform[] ringTransforms = new Transform[4];

    [HideInInspector]
    public Transform ringEnter;

    public float size = 1f;
    public float lerpSpeed = 10f;
    public float lerpTime = 0;


    [Space]

    public bool isLoop = false;
    public float originSize;
    public float[] lerpSize;
    [SerializeField]
    int loopCnt = 0;

    private void Awake()
    {
        ring = GetComponent<RingBehaviour>();
        SetRings();
        ringEnter = ring.ringEnter;
        originSize = size;
    }

    private void FixedUpdate()
    {
        Scale();
    }

    void SetRings()
    {
        for (int i = 0; i < ring.walls.Length; ++i)
        {
            ringTransforms[i] = ring.walls[i].transform;
        }
    }

    public void RandomData()
    {
        lerpSize = new float[2];

        lerpSize[0] = Random.Range(0, 10);
        lerpSize[1] = Random.Range(2, 10);

        isLoop = true;
        lerpSpeed = Random.Range(0.1f, 1f);
    }


    public void Scale()
    {
        if (isLoop && lerpSize.Length > 0 && lerpTime >= 1)
        {
            lerpTime = 0;

            ++loopCnt;
            loopCnt = loopCnt % lerpSize.Length;

            size = lerpSize[loopCnt];
        }

        lerpTime += Time.deltaTime * lerpSpeed;

        for (int i = 0; i < ringTransforms.Length; ++i)
        {
            if (i < 2)
                ringTransforms[i].localPosition = Vector3.Lerp(ringTransforms[i].localPosition, new Vector3(0, 0, i % 2 == 0 ? -size : size), lerpTime);
            else
                ringTransforms[i].localPosition = Vector3.Lerp(ringTransforms[i].localPosition, new Vector3(i % 3 == 0 ? -size : size, 0, 0), lerpTime);


            ringTransforms[i].localScale = Vector3.Lerp(ringTransforms[i].transform.localScale, new Vector3(0.5f, 1, size * 2), lerpTime);
        }

        ringEnter.localScale = Vector3.Lerp(ringEnter.localScale, Vector3.one * size * 2, lerpTime);

    }

}
