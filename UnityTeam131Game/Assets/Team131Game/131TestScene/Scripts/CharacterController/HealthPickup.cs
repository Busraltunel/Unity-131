using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public AudioSource HealthTake;
    
    

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.HealPlayer(healAmount);
            HealthTake.Play();

            Destroy(gameObject);
        }
    }
}
