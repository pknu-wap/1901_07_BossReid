using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision_Demon : MonoBehaviour
{
    public GameObject Hero;
    public GameObject Demon;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(Hero.GetComponent<Collider>(), Demon.GetComponent<Collider>());
    }
}
