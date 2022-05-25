using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth, currentHealth;

    //public float invincibleLenght = 1f;
    //private float invincibleCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "HEALTH: " + currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }*/
    }

    public void DamagePlayer(int damageAmount)
    {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                //canýn -deðerlere düþmemesi için
                currentHealth = 0;

                GameManager.instance.PlayerDeath();
            }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "HEALTH: " + currentHealth;

    }

    public void HealPlayer(int healAmount)
    {

        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "HEALTH: " + currentHealth;

    }

        /*if (invincibleCounter <= 0)
        {
            invincibleCounter = invincibleLenght;
        }
      }*/

    
}
