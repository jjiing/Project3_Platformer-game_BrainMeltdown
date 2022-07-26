using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandUpByLever : MonoBehaviour
{
    public bool isLeverWork;
    Animator anim;
    private void Start()
    {
        isLeverWork = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isLeverWork)
        {
            isLeverWork = false;
            anim.SetTrigger("isLandUp");
        }
    }
}
