using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    int health = 10;
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collisionObject = coll.gameObject;
        if (collisionObject.CompareTag("bullet"))
        {
            // take damage from bullet
            BulletScript script = collisionObject.GetComponent<BulletScript>();
            health -= script.Damage;
                // update score
               HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
               hud.AddPoints(100);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("bullet"))
        {
            // update score
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(100);
        }
    }
}
