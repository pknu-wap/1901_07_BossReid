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

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.tag("")
    }


}
