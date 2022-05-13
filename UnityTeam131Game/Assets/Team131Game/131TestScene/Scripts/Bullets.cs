using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody rb;

    public GameObject bulletEffect;

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
        if (other.gameObject.tag == "Enemy1")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
        Instantiate(bulletEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
    }
}
