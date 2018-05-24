using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviour : MonoBehaviour
{
    Transform tr;

    public GameObject[] walls;
    public Transform ringEnter;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    public void Create()
    {
        int componentCount = Random.Range(0, 4);
        int componentID = 0;
        
        List<int> addIDs = new List<int>();

        for (int i = 0; i < componentCount; ++i)
        {
            int result = -1;

            do
            {
                componentID = Random.Range(1, 4);
                if (addIDs.Count > 0)
                {
                    result = addIDs.Find(item => item == componentID);
                }
                else
                {
                    break;
                }
            }
            while (result != 0);


            addIDs.Add(componentID);

            switch (componentID)
            {
                case 1:
                    gameObject.AddComponent<RingMover>().RandomData();
                    break;
                case 2:
                    gameObject.AddComponent<RingRotater>().RandomData();
                    break;
                case 3:
                    gameObject.AddComponent<RingScaler>().RandomData();
                    break;

                default:
                    Debug.LogError("Ring Component Add is not allow ID = " + componentID);
                    break;
            }


        }
    }

}
