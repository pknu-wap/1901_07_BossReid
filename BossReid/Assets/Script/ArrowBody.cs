using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBody : MonoBehaviour
{
    public GameObject Arrow;            // 복제할 화살 오브젝트
    public Transform ArrowLocation;     // 화살이 발사될 위치
    [Header("재발사 속도")]
    [Range(0f,3f)]
    public float FireDelay;             // 화살 발사 속도(화살이 날아가는 속도x)
    public bool FireState;             // 화살 발사 속도를 제어할 변수
    public float arrowSpeed;

    public int ArrowMaxPool;            //메모리 풀에 저장할 화살 개수
    private MemoryPool MPool;           //메모리 풀
    private GameObject[] ArrowArray;    //메모리 풀이랑 연동해서 사용할 화살 배열

    Rigidbody rb;
    Rigidbody arrowrb;


    private void OnApplicationQuit()
    {
        //메모리 풀을 비웁니다
        MPool.Dispose();
    }


    void Start()
    {
        // 처음에 화살을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;

        //메모리 풀을 초기화 
        MPool = new MemoryPool();

        //Arrow를 ArrowMaxPool만큼 생성
        MPool.Create(Arrow, ArrowMaxPool);
        // 배열도 초기화 (null값)
        ArrowArray = new GameObject[ArrowMaxPool];
    }

    void Update()
    {
        // 매 프레임마다 화살발사 함수를 체크한다.
        playerFire();
    }

    // 화살을 발사하는 함수
    private void playerFire()
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            // 키보드의 "A"를 누르면
            if (Input.GetKey(KeyCode.A))
            {
                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());
                // "Arrow"를 "ArrowLocation"의 위치에 "ArrowLocation"의 방향으로 복제한다.

                //  화살풀에서 발사되지 않은 화살을 찾아서 발사합니다.
                for (int i = 0; i < ArrowMaxPool; i++)
                {
                    // 만약 화살배열[i]가 비어있다면
                    if (ArrowArray[i] == null)
                    {
                        // 메모리풀에서 화살을 가져온다.
                        ArrowArray[i] = MPool.NewItem();
                        // 해당 화살의 위치를 화살 발사지점으로 맞춘다.
                        ArrowArray[i].transform.position = ArrowLocation.transform.position;
                        ArrowArray[i].GetComponent<ArrowMove>().dir = transform.right;
                        // 발사 후에 for문을 바로 빠져나간다.
                        break;
                    }
                }
            }
        }


        // 화살이 발사될때마다 화살을 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < ArrowMaxPool; i++)
        {
            // 만약 화살[i]가 활성화 되어있다면
            if (ArrowArray[i])
            {
                // 화살[i]의 Collider가 비활성 되었다면
                if (ArrowArray[i].GetComponent<BoxCollider>().enabled == false)
                {
                    // 다시 Collider를 활성화 시키고
                    ArrowArray[i].GetComponent<BoxCollider>().enabled = true;
                    // 화살을 메모리로 돌려보내고
                    MPool.RemoveItem(ArrowArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    ArrowArray[i] = null;
                }
            }
        }

        // 코루틴 함수
        IEnumerator FireCycleControl()
        {
            // 처음에 FireState를 false로 만들고
            FireState = false;
            // FireDelay초 후에
            yield return new WaitForSeconds(FireDelay);
            // FireState를 true로 만든다.
            FireState = true;
        }
    }
}