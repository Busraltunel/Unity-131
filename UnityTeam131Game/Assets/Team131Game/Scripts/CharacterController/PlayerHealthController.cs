using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth, currentHealth;

    public AudioClip deathClip;


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

    }

    public void DamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        UIController.instance.ShowDamage();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            // animator.SetBool("isDead", true);

            //canýn -deðerlere düþmemesi için
            currentHealth = 0;

            GameManager.instance.PlayerDeath();

            //UIController.instance.ShowDeathDamage();

            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            AudioManager.instance.StopBGM();
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
}
