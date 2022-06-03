using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody rb;

    public GameObject bulletEffectEnvironment;
    public GameObject bulletEffectEnemy;
    public int damage = 1;

    public bool damageEnemy, damagePlayer;

    public AudioSource EnemyHitSound, PlayerHitSound;
    
    

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
        if (other.gameObject.tag == "NPC" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damage);
            //Debug.Log("Enemy Shot");
            Instantiate(bulletEffectEnemy, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            Destroy(gameObject,1);
        }

        if (other.gameObject.tag == "ShooterEnemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damage);
            //Debug.Log("Enemy2 Shot");
            Instantiate(bulletEffectEnemy, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            EnemyHitSound.Play();
            Destroy(gameObject,1);
        }

        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            //Debug.Log("Player vuruldu" + transform.position);
            PlayerHealthController.instance.DamagePlayer(damage);
            Instantiate(bulletEffectEnemy, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            PlayerHitSound.Play();
            Destroy(gameObject,1);
        }

        if (other.gameObject.tag == "Environment" && damageEnemy)
        {
            Destroy(gameObject,3);
            Instantiate(bulletEffectEnvironment, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
        }

        
        
        
    }
}
