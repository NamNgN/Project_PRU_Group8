using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
	float Speed = 7f;

	public Rigidbody2D rb;


	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * Speed;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("Player"))
		{
			Debug.Log("Hit!");
			col.GetComponent<Health>().TakeDamage(1);

		}
	}
}
