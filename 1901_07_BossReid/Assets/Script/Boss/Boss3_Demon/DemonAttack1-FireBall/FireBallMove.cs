using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{

    public float MoveSpeed;
    public Vector3 dir;
    public GameObject Deadmotion;

    void Update()
    {
        transform.Translate(-dir * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))               // 부딪히는 collision을 가진 객체의 태그가 "Player"일 경우
        {
            Instantiate(Deadmotion, collision.gameObject.transform.position, Quaternion.identity);

            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
   
            GetComponent<Collider>().enabled = false;     // 히어로 맞췄으면 파이어볼 삭제 
        }

        if (collision.CompareTag("Ground"))               // 부딪히는 객체 태그가 "Ground" 일 경우 
        {
                   
            GetComponent<Collider>().enabled = false;     // 벽 맞췄으면 파이어볼 삭제 
        }
    }
}
