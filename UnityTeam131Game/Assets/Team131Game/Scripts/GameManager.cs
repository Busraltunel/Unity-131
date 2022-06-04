using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDie = 2f;

    public Animator animator;
    public AudioClip deathClip;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PlayerDeath()
    {
        StartCoroutine(PlayerDeathCo());

        //direkt respawn etme
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator PlayerDeathCo()
    {
        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        //animator.SetBool("isDead", true);

        yield return new WaitForSeconds(waitAfterDie);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnpause()
    {
        if (UIController.instance.pauseScreen.activeInHierarchy)
        {
            UIController.instance.pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else
        {
            UIController.instance.pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
            
    }
}
