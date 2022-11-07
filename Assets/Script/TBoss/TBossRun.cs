using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBossRun : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 1f;
    Transform player;
    Rigidbody2D rb;
    BossT boss;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossT>();
    }

     
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 tagget = new Vector2(player.position.x, player.position.y);
        Vector2 newPo = Vector2.MoveTowards(rb.position, tagget, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPo);


            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Melee");
            }

    }

     
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   /*     animator.ResetTrigger("Melee");*/
    }


}
