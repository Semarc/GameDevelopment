using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.InputSystem;

using Unity.VisualScripting;

using UnityEngine;

public class PlayerShip : Ship
{
	private PlayerControls controls;


	public int speed;

	public override int Health { get; protected set; }


	private Vector2 moveDirection;

	protected override void Awake()
	{
		base.Awake();
		Debug.Log("PlayerShip Awake");
		controls = new PlayerControls();
		controls.ShipControls.Shoot.performed += Shoot_performed;
		controls.ShipControls.TripleShoot.performed += TripleShoot_performed;
		controls.ShipControls.Enable();
	}

	private void OnMovement(InputValue movementValue)
	{
		Debug.Log("Move Called " + moveDirection);
		moveDirection = movementValue.Get<Vector2>();
	}

	private void TripleShoot_performed(InputAction.CallbackContext obj)
	{
		Debug.Log("TripleShoot");
		bool tripleShoot = obj.ReadValueAsButton();
	}

	private void Shoot_performed(InputAction.CallbackContext obj)
	{
		Debug.Log("Shoot");
		bool shoot = obj.ReadValueAsButton();
	}

	// Update is called once per frame
	private void Update()
	{
		//Vector3 moveVector = Vector3.zero;

		//if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
		//if (Input.GetKey(KeyCode.S)) moveVector.y = -1;

		//moveVector.Normalize();

		//// Frame rate independent movement
		//rb.MovePosition(rb.position + (Vector2)(Time.deltaTime * speed * moveVector));

	}

	private void FixedUpdate()
	{
		Debug.Log("FixedUpdate " + moveDirection);
		rb.velocity =  moveDirection * speed;
	}
}