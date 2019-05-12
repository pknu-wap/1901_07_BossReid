using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날아가는 속도
    public float DestroyYPos;   // 미사일이 사라지는 지점


    void Update()
    {



        //문제가 많은 코드,, 먼저 애드포스로 바꿔야 함 그리고 0일때는 캐릭터 방향 이전상태를 반환할 수 있어야 함 ***
        
        // 캐릭터가 바라보는 방향이 왼쪽이면 
                if (HeroMove.horizontalMove > 0)
              {
            // 매 프레임마다 미사일이 MoveSpeed 만큼 캐릭터가 바라보는 방향으로 날아간다 
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
               }

               else
              {
                // 매 프레임마다 미사일이 MoveSpeed 만큼 캐릭터가 바라보는 방향으로 날아간다 
              transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
              }

       // transform.Translate(Vector3.left* MoveSpeed * Time.deltaTime);


        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면 
        if (transform.position.x >= DestroyYPos)
        {
            // 미사일을 제거
            Destroy(gameObject);
        }
    }
}
