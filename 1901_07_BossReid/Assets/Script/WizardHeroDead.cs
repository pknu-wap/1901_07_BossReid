using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHeroDead : MonoBehaviour
{
    public FireBallMove FBM;
    public GameObject MenuWizard;

    void Update()
    {
        if(FBM.isHeroDead == true)
        {
            MenuWizard.SetActive(true);
        }
    }
}
