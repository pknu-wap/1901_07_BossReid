using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;
    public GameObject playerExplosion;

    void Start()
    {
        target = GameObject.Find("Hero"); // 히어로를 타겟으로
        rb = GetComponent<Rigidbody>(); // rigidbody 불러옴
        moveSpeed = Random.Range(1f, 3f); // 몬스터 움직이는 속도
    }

    void Update()
    {
        MoveMonster();
        Destroy(gameObject, 5f); // 5초 후 파괴됨

    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Player": // 몬스터가 플레이어 태그와 닿을 경우
                MonsterSpawnControl.spawnAllowed = false;
                Instantiate(playerExplosion, col.gameObject.transform.position, Quaternion.identity); // 플레이어 자리에 explosion 발생
                Destroy(col.gameObject); // 플레이어 파괴
                target = null; // 타겟 없음
                break;

            case "Arrow": // 몬스터가 화살 태그와 닿을 경우
                Instantiate(explosion, transform.position, Quaternion.identity); // 몬스터 자리에 explosion 발생
                Destroy(col.gameObject); // 몬스터 파괴
                Destroy(gameObject); // 몬스터 파괴
                break;
        }
    }

    void MoveMonster()
    {
        if (target != null) // 타겟이 없는게 아니라면
        {
            directionToTarget = (target.transform.position - transform.position).normalized; // 타겟 추적
            rb.velocity = new Vector3(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed, 0f); // 추적 속도
        }

        else // 타겟이 없다면
            rb.velocity = Vector3.zero; // 추격 X
    }
}
