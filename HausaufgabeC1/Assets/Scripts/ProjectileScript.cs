using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour
{
	Rigidbody2D rb;

	protected abstract string HostileTag { get; }
	protected abstract int Damage { get; }

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(HostileTag))
		{
			Destroy(gameObject);
		}
		collision.GetComponent<Ship>().DoDamage(Damage);
	}
}