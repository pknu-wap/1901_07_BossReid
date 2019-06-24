using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHP : MonoBehaviour
{
    public float HP;    //demon's HP
    private float MAX_HP;  //demon's max hp
    private bool Live;       //is demon alive?
    public GameObject Explosion;

    //Animator animatorE;


    void Init()
    {
        //animatorE = gameObject.GetComponent<Animator>();

        MAX_HP =100;
        HP = MAX_HP;
        Live = true;

        StartCoroutine("StateCheck");

    }

    private void Update()
    {
        Debug.Log(HP);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init(); 
    }
    
    IEnumerator StateCheck()
    {
        //if demon alive,
        while(Live)
        {
            if(HP==0)
            {
                //animatorE.SetTrigger("isDemonDead");
                gameObject.SetActive(false);
                Debug.Log("보스가 사망!");
                Live = false;
          
            }
            yield return null;
        }
        //죽는 애니메이션 있다면, 죽었을 때 다른 객체의 영향 안받게
        //콜라이더 제거하고 죽는 애니메이션 재생 하고 객체 비활성화


    }
}
