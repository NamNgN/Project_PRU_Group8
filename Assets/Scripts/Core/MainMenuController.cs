using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour

{
    

    public void Playgame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Quitgame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Slectmap()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Slectmap1()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Slectmap2()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
