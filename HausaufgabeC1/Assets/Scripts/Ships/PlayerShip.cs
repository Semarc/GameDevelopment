using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum PlayerAttacks
{
	Shoot,
	TripleShoot,
}


public class PlayerShip : Ship
{
	private class AttacksHeldAndCooldown
	{
		public bool IsOnCooldown = false;
		public bool IsHeld = false;
	}

	[SerializeField] private GameObject ProjectilePrefab;


	private PlayerControls controls;


	[SerializeField] private float speedField;
	protected override float speed => speedField;

	public override int Health { get; protected set; } = 1;


	private Vector2 moveDirection;


	// How many seconds your coroutine will wait before doing its loop again
	[SerializeField] private float shootDelay = .4f;
	[SerializeField] private float tripleShootDelay = 3f;


	private readonly Dictionary<PlayerAttacks, AttacksHeldAndCooldown> AttackOnCooldown = new();

	private bool godMode = false;

	protected override void Awake()
	{
		base.Awake();

		foreach (object item in Enum.GetValues(typeof(PlayerAttacks)))
		{
			AttackOnCooldown.Add((PlayerAttacks)item, new());
		}


		Camera cam = Camera.main;
		Vector2 topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));

		transform.position = topLeft + 2 * (Vector2.down + Vector2.right);


		Debug.Log("PlayerShip Awake");
		controls = new PlayerControls();
		controls.ShipControls.Enable();
	}

	private void OnMovement(InputValue movementValue)
	{
		moveDirection = movementValue.Get<Vector2>();
	}

	private void OnGodMode(InputValue godModeInputValue)
	{
		if (godModeInputValue.Get<float>() != 0)
		{
			godMode = !godMode;
			Debug.Log("Toggeled Godmode" + godMode);
			GameUIManager.Instance.ToogleGodmodText(godMode);
			if (godMode)
			{
				AudioScript.Instance.PlayGodModeActivatedSound();
			}
		}
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
		if (AttackOnCooldown[PlayerAttacks.Shoot].IsOnCooldown == true)
		{
			yield break;
		}
		AttackOnCooldown[PlayerAttacks.Shoot].IsOnCooldown = true;
		while (AttackOnCooldown[PlayerAttacks.Shoot].IsHeld)
		{
			HelperFunctions.InstantiateChildObject(gameObject, ProjectilePrefab);
			AudioScript.Instance.PlayShotSound();

			yield return new WaitForSeconds(shootDelay);

			// can also be 'yield return null;' if you want this to loop every frame
			// but that can be taxing on some computers, depending on what you are doing
		}
		AttackOnCooldown[PlayerAttacks.Shoot].IsOnCooldown = false;
	}

	// This gets called when the action is performed
	// In this case, that means this gets called both when the button is
	// pressed & when the button is held down
	void handleShoot(InputAction.CallbackContext obj)
	{
		AttackOnCooldown[PlayerAttacks.Shoot].IsHeld = true;
		// Do whatever needs to be done if the button is held down
		StartCoroutine(ShootHoldCo());
	}


	// This gets called when the action is canceled
	// In this case, that is when we release the button
	void handleShootCancel(InputAction.CallbackContext obj)
	{
		if (AttackOnCooldown[PlayerAttacks.Shoot].IsHeld)
		{
			AttackOnCooldown[PlayerAttacks.Shoot].IsHeld = false;
			// Anything else you need to do upon canceling your action
			//EndAttack(); // This can be anything, doesn't matter for this explanation
		}
	}

	#endregion


	#region TripleShoot

	IEnumerator TripleShootHoldCo()
	{
		if (AttackOnCooldown[PlayerAttacks.TripleShoot].IsOnCooldown == true)
		{
			yield break;
		}
		AttackOnCooldown[PlayerAttacks.TripleShoot].IsOnCooldown = true;
		while (AttackOnCooldown[PlayerAttacks.TripleShoot].IsHeld)
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
		AttackOnCooldown[PlayerAttacks.TripleShoot].IsOnCooldown = false;
	}

	// This gets called when the action is performed
	// In this case, that means this gets called both when the button is
	// pressed & when the button is held down
	void handleTripleShoot(InputAction.CallbackContext obj)
	{
		AttackOnCooldown[PlayerAttacks.TripleShoot].IsHeld = true;
		// Do whatever needs to be done if the button is held down
		StartCoroutine(TripleShootHoldCo());
	}


	// This gets called when the action is canceled
	// In this case, that is when we release the button
	void handleTripleShootCancel(InputAction.CallbackContext obj)
	{
		if (AttackOnCooldown[PlayerAttacks.TripleShoot].IsHeld)
		{
			AttackOnCooldown[PlayerAttacks.TripleShoot].IsHeld = false;
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

	public override void DoDamage(int Damage)
	{
		if (!godMode)
		{
			Debug.Log("Player Destroyed");
			AudioScript.Instance.PlayPlayerHitSound();
			ParticleManager.Instance.PlayerExplosion(transform.position);
			speedField = 0;
			StartCoroutine(PlayerDestroyed());
		}
	}


	IEnumerator PlayerDestroyed()
	{
		float time = 1;
		while (time > 0)
		{
			yield return null;
			time -= Time.deltaTime;
			AudioScript.Instance.SetVolume(time);
		}

		AudioScript.Instance.SetVolume(1);
		AudioScript.Instance.PlayMusic();
		SceneManager.LoadScene(0);
	}
}