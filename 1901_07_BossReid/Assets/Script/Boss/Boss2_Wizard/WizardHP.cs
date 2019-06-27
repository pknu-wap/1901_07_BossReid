using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardHP : MonoBehaviour
{
    public float HP;    //wizard's HP
    private float MAX_HP;  //wizard's max hp
    private bool Live;       //is wizard alive?
    public GameObject Deadmotion;

    public Slider hpSlider;


    void Init()
    {

        MAX_HP = 100;
        HP = MAX_HP;
        Live = true;

        StartCoroutine("StateCheck");

    }

    private void Update()
    {
        hpSlider.maxValue = MAX_HP;
        hpSlider.value = HP;
    }

    void Start()
    {
        Init();
    }

    IEnumerator StateCheck()
    {
        //if wizard alive,
        while (Live)
        {
            if (HP == 0)
            {
                Instantiate(Deadmotion, transform.position, Quaternion.identity); //보스 체력이 0이라면, 보스 있던 자리에 폭발 애니메이션 재생

                GameObject.Find("Explosion").GetComponent<AudioSource>().Play();

                gameObject.SetActive(false);
                Live = false;

            }
            yield return null;
        }

    }
}
