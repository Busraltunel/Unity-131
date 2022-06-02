using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    private bool collected;
    public AudioSource AmmoTake;

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player" && !collected)
        {

            PlayerController.instance.activeWeapon.GetAmmo();
            AmmoTake.Play();


            Destroy(gameObject);

            collected = true;

        }
    }
}
