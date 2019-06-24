using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionThingsDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,1f); 
    }

    //플레이어 죽는 애니메이션 1번만 재생되게 했는데 
    //마지막 프레임이 안지워지는 현상 있어서 그냥 
    //애니메이션 생성 후 1 초 뒤 삭제되게 만들어 놓음 
    //이 스크립트 붙이고 그거 소환되면 1 초 뒤 삭제됨 여기저기 쓰셈
}
