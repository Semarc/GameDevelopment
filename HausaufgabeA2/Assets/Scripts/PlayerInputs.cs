using System;
using System.Collections.Generic;

using UnityEngine;


public class PlayerInputs : MonoBehaviour
{
	#region Initilisation and Fields

	private readonly Dictionary<KeyCode, char> letterKeys = new();

	private readonly Dictionary<KeyCode, int> numberKeys = new();

	// Speed of the character
	[SerializeField] int speedIndex = 0;

	[SerializeField] float[] possibleSpeeds = {5f, 10f, 20f };

	SpriteRenderer[] sr;

	bool IsFlipped = false;

	bool IsDancing = false;
	string enteredKeys = string.Empty;

	private Dictionary<string, Action> cheatCodes;


	// Cache the SpriteRenderer (could also be done in Start())
	void Awake()
	{
		sr = GetComponentsInChildren<SpriteRenderer>();
		for (int i = 97; i < 123; i++)
		{
			letterKeys.Add((KeyCode)i, (char)i);
		}

		for (int i = 0; i < 10; i++)
		{
			numberKeys.Add((KeyCode)(i + 48), i);
			numberKeys.Add((KeyCode)(i + 256), i);
		}

		foreach (var item in numberKeys)
		{
			Debug.Log(item.ToString());
		}

		cheatCodes = new Dictionary<string, Action>()
		{
			{ "NINJA", cheatNinja },
			{ "DOGE", cheatDoge },
			{ "SQUIDGAME", cheatSquidgame},
		};
	}

	#endregion

	void Update()
	{
		//Check Each Letter for The Cheat Codes
		foreach (KeyValuePair<KeyCode, char> item in letterKeys)
		{
			if (Input.GetKeyDown(item.Key))
			{
				enteredKeys += item.Value.ToString().ToUpperInvariant();
			}
		}

		if (!IsDancing)
		{

			//Activate The Cheats
			foreach (KeyValuePair<string, Action> item in cheatCodes)
			{
				if (enteredKeys.Contains(item.Key))
				{
					item.Value();
					enteredKeys = string.Empty;
					break;
				}
			}

			InputMoveCharacter();

			//Activate DanceMoves
			foreach (KeyValuePair<KeyCode, int> item in numberKeys)
			{
				if (item.Value >= DanceMoves.PlayerDanceMoves.Length)
				{
					break;
				}
				if (Input.GetKeyDown(item.Key))
				{
					DanceMoves.PlayerDanceMoves[item.Value](transform);
				}
			}

		}



		if (Input.GetKeyDown(KeyCode.F))
		{
			SpawnNewLight();
		}







		void InputMoveCharacter()
		{
			Vector3 moveVector = Vector3.zero;

			// Get input and save state in moveVector
			if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
			if (Input.GetKey(KeyCode.A)) moveVector.x = -1;
			if (Input.GetKey(KeyCode.S)) moveVector.y = -1;
			if (Input.GetKey(KeyCode.D)) moveVector.x = 1;
			//if (Input.GetKeyDown(KeyCode.LeftShift))
			//{
			//	speedIndex = (speedIndex + 1) % possibleSpeeds.Length;
			//}

			// Normalize vector, so that magnitude for diagonal movement is also 1
			moveVector.Normalize();

			// Frame rate independent movement
			transform.position += Time.deltaTime * possibleSpeeds[speedIndex] * moveVector;

			// Flip the sprite if facing to the left
			if (moveVector.x < 0 && !IsFlipped)
			{
				IsFlipped = true;
				ChangeDirection();
			}
			else if (moveVector.x > 0 && IsFlipped)
			{
				IsFlipped = false;
				ChangeDirection();
			}

			void ChangeDirection()
			{
				transform.position = new Vector3(transform.position.x - 2 * (transform.position.x - GetAllChildBounds().center.x), transform.position.y);
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
			}
		}
	}


	public Bounds GetAllChildBounds()
	{
		if (sr.Length == 0)
			return new Bounds();
		Bounds bounds = sr[0].bounds;
		foreach (SpriteRenderer renderer in sr)
		{
			//Debug.Log(bounds);
			//Debug.Log(renderer.gameObject.name);
			bounds.Encapsulate(renderer.bounds);
		}
		//Debug.Log(bounds);
		return bounds;
	}

	private void SpawnNewLight()
	{

	}

	#region Cheats

	private void cheatNinja()
	{

	}
	private void cheatDoge()
	{

	}
	private void cheatSquidgame()
	{

	}

	#endregion

}