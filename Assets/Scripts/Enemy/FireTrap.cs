using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{

    [SerializeField] private float damage;

    [Header("Firetrap Timer")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    [Header("SFX")]
    [SerializeField] private AudioClip fireTrapSound;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private Health playerHealth;

    private bool triggerd; // when traps get triggered
    private bool active; // when traps is active and hurt player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if (!triggerd)
            {//trigger fire trap
                StartCoroutine(ActiveFireTrap());

            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }

    }

    private IEnumerator ActiveFireTrap()
    {
        //Turn the prite red to notify its triggered
        triggerd = true;
        spriteRenderer.color = Color.red;//notify

        //wait delay
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(fireTrapSound);
        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        //wait x second to de activate and reset 
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggerd = false;
        anim.SetBool("activated", false);




    }


}
