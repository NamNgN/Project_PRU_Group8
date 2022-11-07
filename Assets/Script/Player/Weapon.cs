using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform GunPoint;
    public GameObject bulletPrefab;
    public GameObject pBulletPrefab;
    public GameObject powerupBullet;
    public GameObject currentBullet;
    public float pBulletTimeCounter=10f;
    public float pBulletTime;
    private bool direction;
    public bool isPoweredUp;
    float timeUntilFire;

     CharacterMovement playerdirection;
    [Header("Shoot")]
    [SerializeField] private AudioClip shootSoundEffect;
    [Header("PowerUp")]
    [SerializeField] private AudioClip powerupShootSE;
    private void Start()
    {
        playerdirection = gameObject.GetComponent<CharacterMovement>();
        direction = true;
        currentBullet = bulletPrefab;

        powerupBullet = pBulletPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoweredUp == true)
        {
            pBulletTime = pBulletTimeCounter;
            pBulletTimeCounter -= Time.deltaTime;
            if(pBulletTime <= 0)
            {
                isPoweredUp = false;
            }
        }
        direction = playerdirection.isRight;
        if (direction==true)
        {
            GunPoint.localPosition = new Vector3(1f, -0.5f, 0);
        }
        if (direction==false)
        {
            GunPoint.localPosition = new Vector3(-1f, -0.5f, 0);
        }
    }

   public void Shoot()
    {

        float angle = playerdirection.isRight ? 0f : 180f;

        
        if (timeUntilFire < Time.time)
        {
            if (isPoweredUp == false)
            {
                SoundManager.instance.PlaySound(shootSoundEffect);
                Instantiate(currentBullet, GunPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
            if (isPoweredUp == true)
            {
                SoundManager.instance.PlaySound(powerupShootSE);
                Instantiate(powerupBullet, GunPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
            
            timeUntilFire = Time.time + fireRate;
            
        }
   

    }

}

