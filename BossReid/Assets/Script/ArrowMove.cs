using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float MoveSpeed;     // 화살이 날아가는 속도

    //    public float DestroyYPos;   // 화살이 사라지는 지
    public Vector3 dir;
    public void Start()
    {
    }

    void Update()
    {

        transform.Translate(dir * MoveSpeed * Time.deltaTime);


        // 만약에 미사일의 위치가 DestroyXPos를 넘어서면 
        //이 부분은 새로 만들어야 할 듯 왼편으로 쭉 날아가는 건 삭제가 안됨
        //if (transform.position.x >= DestroyYPos)
        // {
        // 미사일을 제거
        //Destroy(gameObject);
        //}
    }
}
