using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTeller : MonoBehaviour
{
    public Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            animator.SetTrigger("aaa");
        }
    }
}

