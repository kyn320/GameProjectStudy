using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingGenerator : MonoBehaviour
{

    /*
     랜덤으로 링 생성
     
     고정 요소
     1. 링의 위치
      
     랜덤 요소
     1. 사이즈
     2. 움직이는 위치
     3. 회전 값

     */

    public Vector3 startPos;
    public float currentHeight;
    public float addHeight;

    public int ringCount;

    public float minSize, maxSize;

    public List<GameObject> ringList;

    private void Awake()
    {
        currentHeight = startPos.y;
    }

    private void Start()
    {
        Generate(100);
    }

    void Generate(int count = 0)
    {
        for (int i = 0; i < count; ++i)
        {
            GameObject g = Instantiate(ringList[Random.Range(0, ringList.Count)]
                 , startPos + (Vector3.up * addHeight * ringCount)
                 , Quaternion.identity);

            ++ringCount;
            g.GetComponent<RingBehaviour>().Create();
        }

        currentHeight = startPos.y + addHeight * ringCount;
    }

}
