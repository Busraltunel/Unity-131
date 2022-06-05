using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float sayi;
    public TMP_Text loadingHint, sayiText;
    public GameObject bar, screen;
    public int hint;
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Start()
    {
        screen.SetActive(true);
        hint = Random.Range(0, 4);
    }

   
    void Update()
    {
        sayiText.text = "" + (int)sayi + "%";
        bar.transform.localScale = new Vector3(sayi / 100, 1, 1);
        if (sayi < 100)
        {
            sayi += Time.deltaTime * 9;
        }
        if (sayi >= 100)
        {
            sayi = 100;
            //screen.SetActive(false);
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        if (hint == 0)
        {
            loadingHint.text = "HINT: Nobyl 2 and Fukushima 1 nuclear power plants and their surrounding areas are the most damaged areas.";
        }
        if (hint == 1)
        {
            loadingHint.text = "HINT: The liquidator is the person who responsible for cleaning the nuclear power plant and its surroundings from living beings exposed to active radiation in the area. If necessary, they are responsible for cleaning every living creature in the area...";
        }
        if (hint == 2)
        {
            loadingHint.text = "HINT: It is unknown how many Liquidators there are.";
        }
        if (hint == 3)
        {
            loadingHint.text = "HINT: Use the [E] key to interact with objects such as faucets, radios, doors. But you may need to find locks for some doors.";
        }
    }
}
