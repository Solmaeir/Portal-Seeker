using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame() 
    {

        string startingScene = "1";

        SceneManager.LoadScene(startingScene);

    }
    public void QuitGame() 
    {
    
        Application.Quit();
    
    }
}
