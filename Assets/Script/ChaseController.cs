using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    public BotFlyController[] botArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(BotFlyController bot in botArray)
            {
                bot.chase = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (BotFlyController bot in botArray)
            {
                bot.chase = false;
            }
        }

    }
    
}
