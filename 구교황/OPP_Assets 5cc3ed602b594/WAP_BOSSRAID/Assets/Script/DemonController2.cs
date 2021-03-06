﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * trigger는 한번 true가 되면 애니메이션이 끝난다음 다음 애니메이션으로 전환해줌
 * bool은 안해줌
 * 그래서 jump같은 애니메이션을 하려고 파라미터를 만들면 bool말고 trigger사용.
 */

public class DemonController2 : MonoBehaviour
{
    public float movePower = 1f;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0; // 0 : Idle, 1 : Left, 2 : Right
    bool isTracing;
    GameObject traceTarget;

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

    void FixedUpdate()
    {
        Move();
    }

    void Move() // 몬스터 움직임 정의
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing) // 추적 중이라면 dist에 따라 움직임
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";

            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }

        else // 추적 중이 아니라면 Flag에 따라 움직임
        {
            if (movementFlag == 1)
                dist = "Left";

            else if (movementFlag == 2)
                dist = "Right";
        }

        if(dist == "Left") // 적이 플레이어보다 오른쪽에 있으면 왼쪽으로 가게 함
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(dist == "Right") // 적이 플레이어보다 왼쪽에 있으면 오른쪽으로 가게 함
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) // 인식 범위 내에 들어왔을 때
    {
        if(other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }

    void OnTriggerStay2D(Collider2D other) // 인식 범위 내에 있을 때
    {
        if(other.gameObject.tag == "Player")
        {
            isTracing = true;

            animator.SetBool("isWalking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other) // 인식 범위 밖으로 나갈 때
    {
        if(other.gameObject.tag == "Player")
        {
            isTracing = false;

            StartCoroutine("ChangeMovement");
        }
    }
}