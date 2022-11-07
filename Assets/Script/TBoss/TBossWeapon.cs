using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBossWeapon : MonoBehaviour
{
	public int attackDamage = 1;
	/*public int enragedAttackDamage = 40;*/

	public Vector3 attackOffset;
	public float attackRange = 1.5f;
	public LayerMask attackMask;
    private Health playerHealth;

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		/*		if (colInfo == null)
				{*/
		//playerHealth.GetComponent<Health>().TakeDamage(1);
            colInfo.GetComponent<Health>().TakeDamage(attackDamage);
		
	/*	}*/
	}

/*	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Health>().TakeDamage(enragedAttackDamage);
		}
	}*/

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
