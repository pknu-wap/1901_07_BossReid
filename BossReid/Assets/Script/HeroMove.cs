using System.Collections; using System.Collections.Generic; using UnityEngine;  public class HeroMove : MonoBehaviour  {      public float moveSpeed = 2f;    //이동 속도     public float jumpPower = 3f;    //점프 속도       public int jumpCount = 2; //점프횟수    2를 3으로 바꾸면 3단 점프      new Rigidbody rigidbody;     Animator animator;      bool isGrounded = false;      bool isJumping;     Vector3 movement;      public static float horizontalMove;

        void Awake()     {         rigidbody = GetComponent<Rigidbody>(); //컴포넌트를 불러옴         animator = GetComponent<Animator>(); //애니메이터 불러오기          jumpCount = 0;     }       private void OnCollisionEnter(Collision col)      {         if (col.gameObject.tag == "Ground")         {             isGrounded = true;    //Ground에 닿으면 isGround는 true             jumpCount = 2;          //Ground에 닿으면 점프횟수가 2로 초기화됨
        }     }        void Update()      {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {          isJumping = true;         animator.SetTrigger("isJumping");         }         
         RunAnimationUpdate();         JumpAnimationUpdate();      }     void FixedUpdate()
    {
        Run();         Jump();
    }
     //----------------------     void Run()
    {        if(horizontalMove >0) //왼쪽이동 
        {             Vector3 scale = transform.localScale;             scale.x = Mathf.Abs(scale.x);             transform.localScale = scale;             movement.Set (horizontalMove,0,0);             movement = movement.normalized * moveSpeed * Time.deltaTime;             rigidbody.MovePosition(transform.position + movement);
        }       else if(horizontalMove < 0) //오른쪽 이동 
        {
            Vector3 scale = transform.localScale;             scale.x = -Mathf.Abs(scale.x);             transform.localScale = scale;             movement.Set(horizontalMove, 0, 0);
            movement = movement.normalized * moveSpeed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + movement);
        }
    }       void Jump()
    {
        if(isGrounded)  //땅에 붙어있을 때
        {              if(jumpCount>0)  //점프 카운터가 남아 있으면
            {                  if (!isJumping)                   return;                       rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);                      jumpCount--;                      isJumping = false;
            } 
        } 
    } 
    void RunAnimationUpdate()
    {
        if (horizontalMove == 0)
        {
            animator.SetBool("isRunning", false);
        }         else
        {
            animator.SetBool("isRunning", true);
        }
    }      void JumpAnimationUpdate()
    {
        if(isJumping)
        {
            animator.SetBool("doJumping", false);
        }          else         {             animator.SetBool("doJumping", true);         } 
    }
         
}  