using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterIsLava : MonoBehaviour
{


    public int damage = 1;

    public bool damagePlayer;



    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }

        if (other.gameObject.tag == "NPC" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }

        if (other.gameObject.tag == "ShooterEnemy" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }
    }
}

