using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class Ship : MonoBehaviour
{
	public abstract int Health { get; protected set; }

	protected Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	public void DoDamage(int Damage)
	{
		Health -= Damage;
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}