using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    [SerializeField]
    private float movementDistance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    private bool movingUp;
    private float TopEdge;
    private float BottomEdge;

    // Start is called before the first frame update
    private void Awake()
    {

        TopEdge = transform.position.y - movementDistance;

        BottomEdge = transform.position.y + movementDistance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            if (transform.position.y > TopEdge)
            {
                transform.position = new Vector3(transform.position.x ,
                    transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y < BottomEdge)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
