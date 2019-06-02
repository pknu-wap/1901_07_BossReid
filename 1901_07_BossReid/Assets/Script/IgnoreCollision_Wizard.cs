using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision_Wizard : MonoBehaviour
{
    public GameObject Hero;
    public GameObject Wizard;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(Hero.GetComponent<Collider>(), Wizard.GetComponent<Collider>());
    }
}
