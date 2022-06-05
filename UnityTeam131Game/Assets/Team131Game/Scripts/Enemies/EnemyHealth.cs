using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 5;
    public GameObject DeadEnemy;

    public EnemyController enemyCon;

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

        if (enemyCon != null)
        {
            enemyCon.GetShot();
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 3);
            Instantiate(DeadEnemy, transform.position, transform.rotation);

        }

    }
}