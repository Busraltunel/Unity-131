using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LevelExit : MonoBehaviour
{
    public static LevelExit instance;

    public string nextLevel;

    public float waitToEndLevel = 2f;
    private Scene scene;

    private void Awake()
    {
        instance = this;

        scene = SceneManager.GetActiveScene();
    }

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
        //PlayerPrefs.SetString(nextLevel + "_cp", "");

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
