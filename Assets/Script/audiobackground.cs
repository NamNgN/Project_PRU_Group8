using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audiobackground : MonoBehaviour
{
    public static audiobackground instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(transform.gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
       
       
    }

    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
    //    {
    //        audiobackground.instance.GetComponent<AudioSource>().Play();
    //    }
    //    else
    //    {
    //        audiobackground.instance.GetComponent<AudioSource>().Pause();
    //    }
    //}
}
