using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public bool moveRight = true;
    public Transform groundDetection;

    public LayerMask groundLayer;
    public Collider2D collider;
    public Rigidbody2D rb;
    [SerializeField]
    public Transform player;
    SpriteRenderer sprite;
    [SerializeField]
    public float argoRange;

    private void Start()
    {
        
    }
    void Update()
    {
        EnemyMovement();

        float disToPlayer = Vector2.Distance(transform.position, player.position);
        if(disToPlayer < argoRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }

    }
    void EnemyMovement()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false || collider.IsTouchingLayers(groundLayer))
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

    void ChasePlayer()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (transform.position.x < player.position.x && (!collider.IsTouchingLayers(groundLayer)|| groundInfo.collider == true))
        {
            rb.velocity = new Vector2(walkSpeed + 1, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-walkSpeed - 1, 0);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
    void StopChasing()
    {

    }
}
