using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	private static readonly KeyCode[] keyCodes = {
		//KeyCode.Alpha0,
		//KeyCode.Keypad0,
		KeyCode.Alpha1,
		KeyCode.Keypad1,
		KeyCode.Alpha2,
		KeyCode.Keypad2,
		KeyCode.Alpha3,
		KeyCode.Keypad3,
		KeyCode.Alpha4,
		KeyCode.Keypad4,
		KeyCode.Alpha5,
		KeyCode.Keypad5,
		//KeyCode.Alpha6,
		//KeyCode.Keypad6,
		//KeyCode.Alpha7,
		//KeyCode.Keypad7,
		//KeyCode.Alpha8,
		//KeyCode.Keypad8,
		//KeyCode.Alpha9,
		//KeyCode.Keypad9,
	 };

	// Speed of the character
	[SerializeField] int speedIndex = 0;

	[SerializeField] float[] possibleSpeeds = {5f, 10f, 20f };

	[SerializeField] int MyCharacterIndex = 0;

	static int CurrentCharacterIndex = 1;

	SpriteRenderer[] sr;

	bool IsFlipped = false;

	// Cache the SpriteRenderer (could also be done in Start())
	void Awake()
	{
		sr = GetComponentsInChildren<SpriteRenderer>();
	}

	void Update()
	{
		for (int i = 0; i < keyCodes.Length; i++)
		{
			if (Input.GetKeyDown(keyCodes[i]))
			{
				int numberPressed = Mathf.FloorToInt(i/2);
				CurrentCharacterIndex = numberPressed;
			}
		}

		if (MyCharacterIndex != CurrentCharacterIndex)
		{
			return;
		}
		else
		{
			CameraFollower.target = this.transform;
		}

		Vector3 moveVector = Vector3.zero;


		for (int i = 0; i < keyCodes.Length; i++)
		{
			if (Input.GetKeyDown(keyCodes[i]))
			{
				int numberPressed = Mathf.FloorToInt(i/2);
				CurrentCharacterIndex = numberPressed;
			}
		}

		// Get input and save state in moveVector
		if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
		if (Input.GetKey(KeyCode.A)) moveVector.x = -1;
		if (Input.GetKey(KeyCode.S)) moveVector.y = -1;
		if (Input.GetKey(KeyCode.D)) moveVector.x = 1;
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speedIndex = (speedIndex + 1) % possibleSpeeds.Length;
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			foreach (SpriteRenderer renderer in sr)
			{
				renderer.color = Random.ColorHSV();
			}
		}


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


		//Debug.Log("Update");
		//foreach (SpriteRenderer renderer in sr)
		//{
		//	Debug.Log(renderer.gameObject.name);
		//	if (moveVector.x < 0)
		//		renderer.flipX = true;
		//	else if (moveVector.x > 0)
		//		renderer.flipX = false;
		//}
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
}