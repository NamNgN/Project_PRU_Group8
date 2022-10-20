using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform inDoor;

    public static float PlayerHealth;
    public static int score;
    public static int Coin;
    private int finalScore;

    private void Start()
    {
        //PlayerHealth = (float) GetComponent<Health>().currenHealth;
        //score = GetComponent<HUD>().score;
        //Coin = GetComponent<HUD>().coin;
        //finalScore = score + Coin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //if (collision.transform.position.x <transform.position.x)
            //{
            //    inDoor.GetComponent<Botreset>().ActivationBot(false);
            //    SceneManager.LoadScene("Level2");

            //}
            //else
            //{
            //    inDoor.GetComponent<Botreset>().ActivationBot(true);   

            //}
            if (SceneManager.GetActiveScene().name=="Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }





        }    
    }


}
