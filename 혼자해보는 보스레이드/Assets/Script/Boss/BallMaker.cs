using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaker : MonoBehaviour
{
    public GameObject[] ballArr = new GameObject[7];
    public GameObject[] tempArr = new GameObject[7];

    private float nowTime;
    private float makeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - nowTime > makeTime)
        {
            nowTime = Time.time;

            float distance = 0f;

            for(int i = 0; i < 7; i++)
            {
                tempArr[i] = Instantiate(ballArr[i], new Vector3(-3f + distance, 3.5f, 0), transform.rotation);
                distance += 1f;
                Destroy(tempArr[i], 3f);
            }
        }    
    }
}
