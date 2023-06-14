using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShip : Ship
{
	private const int speed = 1;

	public override int Health { get; protected set; }

	// Update is called once per frame
	void Update()
	{
		Vector3 moveVector = Vector3.zero;

		if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
		if (Input.GetKey(KeyCode.S)) moveVector.y = -1;

		moveVector.Normalize();

		// Frame rate independent movement
		rb.MovePosition(rb.position + (Vector2)(Time.deltaTime * speed * moveVector));

	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		
	}
}
