using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main/Scenes/CutScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
