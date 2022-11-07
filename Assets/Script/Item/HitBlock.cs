using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBlock : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _hit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var character = collision.collider.GetComponent<CharacterMovement>();
        if(character && collision.contacts[0].normal.y > 0)
        {
            _hit?.Invoke();
        }


    }

}
