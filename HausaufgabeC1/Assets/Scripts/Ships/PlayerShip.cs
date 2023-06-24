using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.InputSystem;

using Unity.VisualScripting;

using UnityEngine;

public enum PlayerAttacks
{
	Shoot,
	TripleShoot,
}


public class PlayerShip : Ship
{
	[SerializeField] private GameObject ProjectilePrefab;


	private PlayerControls controls;


	public int speed;

	public override int Health { get; protected set; } = 20;


	private Vector2 moveDirection;



	private bool isAttackHeld;

	// How many seconds your coroutine will wait before doing its loop again
	[SerializeField] private float shootDelay = .4f;
	[SerializeField] private float tripleShootDelay = 3f;


	private readonly Dictionary<PlayerAttacks, bool> AttackOnCooldown = new();


	protected override void Awake()
	{
		base.Awake();

		foreach (object item in Enum.GetValues(typeof(PlayerAttacks)))
		{
			AttackOnCooldown.Add((PlayerAttacks)item, false);
		}


		Debug.Log("PlayerShip Awake");
		controls = new PlayerControls();
		controls.ShipControls.Enable();
	}

	private void OnMovement(InputValue movementValue)
	{
		Debug.Log("Move Called " + moveDirection);
		moveDirection = movementValue.Get<Vector2>();
	}

	//private void OnShoot(InputValue shootValue)
	//{
	//	bool isShooting = shootValue.Get<float>() != 0;
	//	Debug.Log("On Shoot " + isShooting);
	//	if (isShooting)
	//	{
	//		Instantiate(ProjectilePrefab, transform, false);
	//	}
	//}



	// Subscribe your methods to the performed & canceled actions on enable
	void OnEnable()
	{
		controls.ShipControls.Shoot.performed += handleShoot;
		controls.ShipControls.Shoot.canceled += handleShootCancel;

		controls.ShipControls.TripleShoot.performed += handleTripleShoot;
		controls.ShipControls.TripleShoot.canceled += handleTripleShootCancel;
	}

	// Unsubscribe your methods to the performed & canceled actions on disable
	void OnDisable()
	{
		controls.ShipControls.Shoot.performed -= handleShoot;
		controls.ShipControls.Shoot.canceled -= handleShootCancel;

		controls.ShipControls.TripleShoot.performed -= handleTripleShoot;
		controls.ShipControls.TripleShoot.canceled -= handleTripleShootCancel;
	}

	#region Shoot

	IEnumerator ShootHoldCo()
	{
		if (AttackOnCooldown[PlayerAttacks.Shoot] == true)
		{
			yield break;
		}
		AttackOnCooldown[PlayerAttacks.Shoot] = true;
		while (isAttackHeld)
		{
			Transform temp =  Instantiate(ProjectilePrefab, transform, false).transform;

			temp.SetPositionAndRotation(transform.position, ProjectilePrefab.transform.rotation);

			yield return new WaitForSeconds(shootDelay);

			// can also be 'yield return null;' if you want this to loop every frame
			// but that can be taxing on some computers, depending on what you are doing
		}
		AttackOnCooldown[PlayerAttacks.Shoot] = false;
	}

	// This gets called when the action is performed
	// In this case, that means this gets called both when the button is
	// pressed & when the button is held down
	void handleShoot(InputAction.CallbackContext obj)
	{
		isAttackHeld = true;
		// Do whatever needs to be done if the button is held down
		StartCoroutine(ShootHoldCo());
	}


	// This gets called when the action is canceled
	// In this case, that is when we release the button
	void handleShootCancel(InputAction.CallbackContext obj)
	{
		if (isAttackHeld)
		{
			isAttackHeld = false;
			// Anything else you need to do upon canceling your action
			//EndAttack(); // This can be anything, doesn't matter for this explanation
		}
	}

	#endregion


	#region TripleShoot

	IEnumerator TripleShootHoldCo()
	{
		if (AttackOnCooldown[PlayerAttacks.Shoot] == true)
		{
			yield break;
		}
		AttackOnCooldown[PlayerAttacks.Shoot] = true;
		while (isAttackHeld)
		{
			for (int i = 0; i < 3; i++)
			{
				Transform temp =  Instantiate(ProjectilePrefab, transform, false).transform;

				temp.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - 1 + i), ProjectilePrefab.transform.rotation);
			}

			yield return new WaitForSeconds(tripleShootDelay);

			// can also be 'yield return null;' if you want this to loop every frame
			// but that can be taxing on some computers, depending on what you are doing
		}
		AttackOnCooldown[PlayerAttacks.Shoot] = false;
	}

	// This gets called when the action is performed
	// In this case, that means this gets called both when the button is
	// pressed & when the button is held down
	void handleTripleShoot(InputAction.CallbackContext obj)
	{
		isAttackHeld = true;
		// Do whatever needs to be done if the button is held down
		StartCoroutine(TripleShootHoldCo());
	}


	// This gets called when the action is canceled
	// In this case, that is when we release the button
	void handleTripleShootCancel(InputAction.CallbackContext obj)
	{
		if (isAttackHeld)
		{
			isAttackHeld = false;
			// Anything else you need to do upon canceling your action
			//EndAttack(); // This can be anything, doesn't matter for this explanation
		}
	}


	#endregion


	//// Update is called once per frame
	//private void Update()
	//{
	//	Vector3 moveVector = Vector3.zero;

	//	if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
	//	if (Input.GetKey(KeyCode.S)) moveVector.y = -1;

	//	moveVector.Normalize();

	//	// Frame rate independent movement
	//	rb.MovePosition(rb.position + (Vector2)(Time.deltaTime * speed * moveVector));

	//}

	private void FixedUpdate()
	{
		moveDirection = new Vector2(0, moveDirection.y);
		rb.velocity = moveDirection * speed;
	}
}