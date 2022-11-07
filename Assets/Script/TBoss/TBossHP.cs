using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBossHP : MonoBehaviour
{
    public Slider slider;
    public Vector3 offSet;
    BulletScript bullet;
    GameObject boss;
    public bool isBossTakenDmg = false;


    public void setMaxHP(float Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;
    }
    public void setHP(float Hp)
    {
        slider.value = Hp;
    }

    private void Awake()
    {


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        slider.gameObject.SetActive(true);

        Debug.Log("B"); 
        if (collision.gameObject.CompareTag("bullet"))
        {

            Debug.Log("A");
            slider.gameObject.SetActive(true);
        }
    }
    public void Update()
    {

        //if (bullet.isBossTakenDmg == true)
        //{
        //    Debug.Log("A");

        //}
        //else
        //{
        //    Debug.Log("B");
        //}
    

        // slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offSet);
        //if (bullet.isBossTakenDmg == true)
        //{
        //    slider.gameObject.SetActive(true);
        //}

    }
}
