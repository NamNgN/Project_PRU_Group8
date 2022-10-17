using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private Transform arrowPoint;
    [SerializeField]
    private GameObject[] arrow;
    private float cooldownTimer;

    
    [Header("shootSound")]
    [SerializeField] private AudioClip arrowShoot;

   
    private void Attack()
    {
        cooldownTimer = 0;
        //SoundManager.instance.PlaySound(arrowShoot);
        arrow[FindArrowShot()].transform.position = arrowPoint.position;
        arrow[FindArrowShot()].GetComponent<EnemyProjectile>().
            ActiveProjectile() ;
      
    }
    private int FindArrowShot()
    {
        for (int i = 0; i < arrow.Length; i++)
        {
            if (!arrow[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >=attackCooldown)
        {
            Attack();
        }
    }
}
