using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 25;

    public bool damageEnemy, damagePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damage);
            Debug.Log("Enemy Shot");
        }

        if (other.gameObject.tag == "Enemy2" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damage);
            Debug.Log("Enemy2 Shot");
        }

        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }
    }
}
