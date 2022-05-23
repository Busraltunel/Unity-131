using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isShooting");

        }    
    }
}
