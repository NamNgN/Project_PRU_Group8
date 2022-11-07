using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public bool activated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            GameObject player = collision.gameObject;

            CharacterMovement move = player.GetComponent<CharacterMovement>();
            activated = true;
            move.jumpTime = 0.4f;
            Destroy(gameObject);
        }
    }
}
