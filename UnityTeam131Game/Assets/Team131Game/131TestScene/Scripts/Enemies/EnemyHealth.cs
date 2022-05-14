using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 5;
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
        Debug.Log("Health decreasing");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
