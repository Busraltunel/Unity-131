using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public string mainMenuScene;
    private void Start()
    {
      
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
       GameManager.instance.PauseUnpause();
    }

    public void LoadOptions()
    {
        
    }

    public void LoadMainMenu()
    {
      
        SceneManager.LoadScene(0);
    }
    
    
}

