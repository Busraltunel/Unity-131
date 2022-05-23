using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody rb;

    public GameObject bulletEffect;
    public int damage = 1;

    public bool damageEnemy, damagePlayer;

    void Start()
    {
        
    }

    
    void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

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
            //Debug.Log("Player vuruldu" + transform.position);
            PlayerHealthController.instance.DamagePlayer(damage);
        }

        Destroy(gameObject);
        Instantiate(bulletEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
    }
}
