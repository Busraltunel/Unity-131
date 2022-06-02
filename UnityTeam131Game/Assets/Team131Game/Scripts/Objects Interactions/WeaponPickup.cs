using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string theGun;
    public AudioSource WeaponTake;
    private bool collected;
    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player" && !collected)
        {

            PlayerController.instance.addWeapon(theGun);
            WeaponTake.Play();

            Destroy(gameObject);

            collected = true;

        }
    }
}
