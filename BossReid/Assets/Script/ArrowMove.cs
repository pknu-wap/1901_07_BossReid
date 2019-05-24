using System.Collections;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{

    public float MoveSpeed;     // 화살이 날아가는 속도

    //    public float DestroyYPos;   // 화살이 사라지는 지
    public Vector3 dir;

    void Update()
    {

        transform.Translate(dir * MoveSpeed * Time.deltaTime);
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.tag("")
    }
    */

    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Boss"일 경우
        if (collision.CompareTag("Boss"))
        {
            Debug.Log("보스를 맞힘");
            GetComponent<Collider>().enabled = false;
        }
        if(collision.CompareTag("Ground"))
        {
            Debug.Log("벽 맞힘");
            GetComponent<Collider>().enabled = false;
        }

    }
    //</Collider> 

}
