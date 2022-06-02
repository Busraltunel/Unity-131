using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 5;
    public GameObject DeadEnemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 3);
            Instantiate(DeadEnemy, transform.position, transform.rotation);

        }

    }
}