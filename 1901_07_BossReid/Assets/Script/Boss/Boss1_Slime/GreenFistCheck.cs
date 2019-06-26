using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFistCheck : MonoBehaviour
{

    public SlimeController state;
    public GameObject Deadmotion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // if (state.isTracing == true)
           // {
                Instantiate(Deadmotion,other.gameObject.transform.position, Quaternion.identity); // 플레이어 자리에 explosion 발생
                Destroy(other.gameObject); // 플레이어 파괴
          //  }

        }
            
    }

}
