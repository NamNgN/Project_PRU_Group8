using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("SpikeHead attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];

    private Vector3 destination;
    private float checkTimer;
    private bool acttacking;

    private Vector3 originalPos;

    [Header("SFX")]
    [SerializeField] private AudioClip SpikeHeadSoundE;
    private void OnEnable()
    {
        Stop();
    }
    private void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Update()
    {
        //Move Spikehead to destination only in player in range
        if (acttacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }

    }
    private void restart()
    {
        gameObject.transform.position = originalPos;
    }

    private void CheckForPlayer()
    {
        //check if see player  
        CalculateDirections();
        //check 4 direction
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !acttacking)
            {
                acttacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
        //directions[0] = transform.right * range; //right
        //directions[1] = -transform.right * range; //left
        //directions[2] = transform.up * range; //up
        directions[0] = -transform.up * range; //down
    }
    private void Stop()
    {
        destination = transform.position;// set destination as current so it stay
        acttacking = false;
        Invoke("restart", 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(SpikeHeadSoundE);
        base.OnTriggerEnter2D(collision);
        if (collision.tag != "Enemy")
        {
            Stop();
        }
        //stop when hit sth
        Stop();

    }

}
