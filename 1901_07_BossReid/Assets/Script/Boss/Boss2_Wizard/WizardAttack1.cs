using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack1 : MonoBehaviour
{

    public GameObject BossFireBall;        // 복제할 파이어볼 오브젝트
    public Transform FireBallLocation;     // 파이어볼이 발사될 위치
    public float FireDelay;                // 파이어볼 발사 속도(날아가는 속도아님)
    public bool FireState;                 // 발사 속도를 제어할 변수

    public int FireBallMaxPool;            // 메모리 풀에 저장할 파이어볼 개수
    private MemoryPool FireBallMPool;      // 메모리 풀
    private GameObject[] FireBallArray;    // 메모리 풀이랑 연동해서 사용할 파이어볼 배열

    private void OnApplicationQuit()
    {
        FireBallMPool.Dispose();          //메모리 풀을 비웁니다
    }

    void Start()
    {
        FireState = true;                                     // 처음에 파이어 볼 발사할 수 있도록 발사 상태 변수를 트루로 만든거
        FireBallMPool = new MemoryPool();                     // 메모리 풀을 초기화 
        FireBallMPool.Create(BossFireBall, FireBallMaxPool);  // BossFireBall을 FireballMaxPool만큼 생성
        FireBallArray = new GameObject[FireBallMaxPool];      // 배열을 초기화 해 줌
    }

    void Update()
    {
        BossFire();                     // 매 프레임마다 파이어볼 발사 함수를 체크한다.
    }

    private void BossFire()  // 파이어볼을 발사하는 함수
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            StartCoroutine(FireCycleControl());          // 코루틴 "FireCycleControl"이 실행되며

            for (int i = 0; i < FireBallMaxPool; i++)    // 파이어볼 풀에서 발사되지 않은 파이어볼을 찾아서 발사
            {
                if (FireBallArray[i] == null)            // 만약 화살배열[i]가 비어있다면
                {
                    FireBallArray[i] = FireBallMPool.NewItem();                                      // 메모리풀에서 파이어볼을 가져옴
                    FireBallArray[i].transform.position = FireBallLocation.transform.position;       // 해당 파이어볼의 위치를 파이어볼 발사지점으로 맞춤
                    FireBallArray[i].GetComponent<FireBallMove>().dir = transform.right;             // X축 기준으로 발사
                    break;                                                                           // 발사 후에 for문을 바로 빠져나감
                }
            }
        }

        for (int i = 0; i < FireBallMaxPool; i++)       // 파이어볼이 발사될때마다 파이어볼을 메모리풀로 돌려보내는 것을 체크
        {
            if (FireBallArray[i])   // 만약 파이어볼[i]가 활성화 되어있다면
            {
                if (FireBallArray[i].GetComponent<BoxCollider>().enabled == false)   // 파이어볼[i]의 Collider가 비활성 되었다면
                {
                    FireBallArray[i].GetComponent<BoxCollider>().enabled = true;     // 다시 Collider를 활성화 시키고
                    FireBallMPool.RemoveItem(FireBallArray[i]);                      // 파이어볼을 메모리로 돌려보내고
                    FireBallArray[i] = null;                                         // 가리키는 배열의 해당 항목도 null(값 없음)로 만듦
                }
            }
        }

        // 코루틴 함수
        IEnumerator FireCycleControl()
        {
            FireState = false;                           // 처음에 FireState를 false로 만들고
            yield return new WaitForSeconds(FireDelay);  // FireDelay초 후에
            FireState = true;                            // FireState를 true로 만든다.
        }
    }
}