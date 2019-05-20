using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStun : MonoBehaviour
{
    public HeroMove player;
    public float stunTime;
    public static bool stun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stun == true)
        {
            Debug.Log("stun!!");
            stunTime = 3;
            player.moveSpeed = 0f;
            stunTime -= Time.time;
        }

        if (stunTime <= 0)
        {
            stun = false;
            stunTime = 0;
            player.moveSpeed = 3f;
            Debug.Log("Stun End!!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stun = true;
        }
    }
}
