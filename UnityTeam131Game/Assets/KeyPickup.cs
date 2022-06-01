using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach");
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach");
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            keySound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);
        }
    }
}
