using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botreset : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private Vector3[] initialPosition;


    private void Awake()
    {
        //save the enemi position
        initialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                initialPosition[i] = enemies[i].transform.position;
            }

        }
    }

    public void ActivationBot(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(false);
                enemies[i].transform.position = initialPosition[i];
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    transform.position = initialPosition[i];
                }

            }
        }
    }
}
