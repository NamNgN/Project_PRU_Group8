using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenuController : MonoBehaviour

{
    

    public void Playgame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Quitgame()
    {
        Application.Quit();
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
        SceneManager.LoadScene("");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
