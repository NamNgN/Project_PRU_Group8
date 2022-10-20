using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    int health = 100;

    // scoring support
    const int MonsterPoints = 10;

    /// <summary>
    /// Take damage on collision with monster
    /// </summary>
    /// <param name="coll">collision info</param>
    /// void OnCollisionEnter2D(Collision2D coll)
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collisionObject = coll.gameObject;
        if (collisionObject.CompareTag("bullet"))
        {
            // take damage from bullet
            BulletScript script = collisionObject.GetComponent<BulletScript>();
            health -= script.Damage;
            
            // check for death
            if (health <= 0)
          {  
                // update score
               HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
               hud.AddPoints(MonsterPoints);
                
                // destroy teddy bear
                Instantiate(prefabExplosion, transform.position,
                    Quaternion.identity);
                Destroy(gameObject);
              //  Destroy(collisionObject);
            }
        }
    }
}
