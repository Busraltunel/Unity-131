using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    public string nextLevel;

    public float waitToEndLevel = 2f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.LevelEnding = true;
            StartCoroutine(EndLevelCo());

        }
    }

    private IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", "");

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
