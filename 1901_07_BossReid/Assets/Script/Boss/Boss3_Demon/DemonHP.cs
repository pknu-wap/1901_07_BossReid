using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHP : MonoBehaviour
{
    public float HP;    //demon's HP
    private float MAX_HP;  //demon's max hp
    private bool Live;       //is demon alive?
    public GameObject Deadmotion;

    public Slider hpSlider;


    void Init()
    {
        MAX_HP =100;
        HP = MAX_HP;
        Live = true;

        StartCoroutine("StateCheck");

    }

    private void Update()
    {
        Debug.Log(HP);

        hpSlider.maxValue = MAX_HP;
        hpSlider.value = HP;
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
                //보스 체력이 0이라면, 보스 있던 자리에 폭발 애니메이션 재생
                Instantiate(Deadmotion, transform.position, Quaternion.identity); 
                gameObject.SetActive(false);
                Debug.Log("보스가 사망!");
                Live = false;
          
            }
            yield return null;
        }
    }
}
