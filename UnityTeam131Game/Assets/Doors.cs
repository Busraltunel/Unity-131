using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool inReach;

    void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    }

    void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
    }

    void DoorCloses()
    {
        door.SetBool("Open", false);
        door.SetBool("Closed", true);

    }
}
