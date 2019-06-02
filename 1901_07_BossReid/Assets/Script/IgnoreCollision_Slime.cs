using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision_Slime : MonoBehaviour
{
    public GameObject Hero;
    public GameObject Slime;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(Hero.GetComponent<Collider>(), Slime.GetComponent<Collider>());
    }
}
