using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Saw : MonoBehaviour
{
    [SerializeField]
    private float movementDistance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
   private bool movingLeft;
    private float LeftEdge; 
    private float RightEdge;

    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;

        RightEdge = transform.position.x + movementDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, 
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, 
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft=true;
            }
        }
        
    }

}
