using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * trigger는 한번 true가 되면 애니메이션이 끝난다음 다음 애니메이션으로 전환해줌
 * bool은 안해줌
 * 그래서 jump같은 애니메이션을 하려고 파라미터를 만들면 bool말고 trigger사용.
 */

public class DemonController : MonoBehaviour
{
    public float movePower = 1f;

    Animator animator;
    Vector3 movement;
    int movementFlag = 0; // 0 : Idle, 1 : Left, 2 : Right

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        // Random Change Movement
        movementFlag = Random.Range(0, 3);

        // Mapping Animation
        if (movementFlag == 0)
            animator.SetBool("isWalking", false);

        else
            animator.SetBool("isWalking", true);

        // Wait 2 Seconds
        yield return new WaitForSeconds(2f);

        // Restart Logic
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}
