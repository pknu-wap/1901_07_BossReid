using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFistCheck : MonoBehaviour
{

    public SlimeController state;
    public GameObject Deadmotion;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // if (state.isTracing == true)
           // {
            Instantiate(Deadmotion,other.gameObject.transform.position, Quaternion.identity); // 플레이어 자리에 explosion 발생
            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject); // 플레이어 파괴
          //  }

        }
            
    }

}
