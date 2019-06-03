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


    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Boss"일 경우
        if (collision.CompareTag("Boss3_Demon"))
        {
            Debug.Log("보스를 맞힘");
            GetComponent<Collider>().enabled = false;
            DemonHP a = collision.gameObject.GetComponent<DemonHP>();
            a.HP -= 1;
        }


      
       if (collision.CompareTag("Boss2_Wizard"))
       {
           Debug.Log("보스를 맞힘");
           GetComponent<Collider>().enabled = false;
           WizardHP b= collision.gameObject.GetComponent<WizardHP>();
           b.HP -= 1;
       }
    

        if (collision.CompareTag("Boss1_Slime"))
        {
            Debug.Log("1번 보스를 맞힘");
            GetComponent<Collider>().enabled = false;
            SlimeHP c= collision.gameObject.GetComponent<SlimeHP>();
            c.HP -= 1;
        }


        if(collision.CompareTag("Ground"))
        {
            Debug.Log("벽 맞힘");
            GetComponent<Collider>().enabled = false;
        }

    }
}