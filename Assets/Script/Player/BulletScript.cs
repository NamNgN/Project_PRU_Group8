using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 1f;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public Rigidbody2D rb;



    //start destroy
    #region Fields

    public int damage = 50;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the damage the fish inflicts
    /// </summary>
    public int Damage
    {
        get { return damage; }
    }

    #endregion

    #region Methods


    /// <summary>
    /// Destroy moster on collision
    /// </summary>
    /// <param name="collision">collision info</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Instantiate<GameObject>(prefabExplosion,
            //    transform.position, Quaternion.identity);
            if (anim != null)
            {
                anim.SetTrigger("explode");
            }
            Destroy(gameObject);

        }
        Destroy(gameObject);
    }
    /// <summary>
    /// Destroy when leave game
    /// </summary>
    void OnBecameInvisible()
    {

        Destroy(gameObject);
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    #endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            collision.GetComponent<Health>().TakeDamage(1); }

        if (anim != null)
        {
            anim.SetTrigger("explode");
        }
        Destroy(gameObject);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    //end destroy 

    void Start()
    {


    }



    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
