using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaptersMenu : MonoBehaviour
{
 public void PlayChapterOne()
 {
  SceneManager.LoadScene(1);
 }

    public void TestScene()
    {
        SceneManager.LoadScene("131TestScene");
    }
}
