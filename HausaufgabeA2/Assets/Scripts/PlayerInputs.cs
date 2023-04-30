using System;
using System.Collections.Generic;

using Random = UnityEngine.Random;

using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class PlayerInputs : MonoBehaviour, IDancer
{
	#region Initilisation and Fields

	private readonly Dictionary<KeyCode, char> letterKeys = new();

	private readonly Dictionary<KeyCode, int> numberKeys = new();

	// Speed of the character
	[SerializeField] private int speedIndex = 1;

	[SerializeField] private float[] possibleSpeeds = {2.5f, 5f, 10f, 20f };
	private float SpeedMultiplier = 1f;

	SpriteRenderer sr;

	private bool IsFlipped = false;

	private bool DogeCheatActive = false;
	private bool NinjaCheatActive = false;
	private bool SquidgameCheatActive = false;

	public bool IsDancing { get; set; } = false;
	string enteredKeys = string.Empty;

	private Dictionary<string, Action> cheatCodes;

	[SerializeField] private GameObject discoLight;
	[SerializeField] private Sprite dogeSprite;
	private AnimalAI[] NPCDancers;

	// Cache the SpriteRenderer (could also be done in Start())
	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		for (int i = 97; i < 123; i++)
		{
			letterKeys.Add((KeyCode)i, (char)i);
		}

		for (int i = 0; i < 10; i++)
		{
			numberKeys.Add((KeyCode)(i + 48), i);
			numberKeys.Add((KeyCode)(i + 256), i);
		}

		cheatCodes = new Dictionary<string, Action>()
		{
			{ "NINJA", cheatNinja },
			{ "DOGE", cheatDoge },
			{ "SQUIDGAME", cheatSquidgame},
		};


		GameObject[] NPCDancersObjects = GameObject.FindGameObjectsWithTag(Constants.NPCDancerTagName);
		List<AnimalAI> tempAnimalAiList = new();
		foreach (GameObject item in NPCDancersObjects)
		{
			tempAnimalAiList.Add(item.GetComponent<AnimalAI>());
		}
		NPCDancers = tempAnimalAiList.ToArray();
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
					IsDancing = true;
					StartCoroutine(DanceMoves.PlayerDanceMoves[item.Value](this));
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
			transform.position += Time.deltaTime * possibleSpeeds[speedIndex] * SpeedMultiplier * moveVector;

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
				transform.position = new Vector3(transform.position.x - 2 * (transform.position.x - Bounds.center.x), transform.position.y);
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
			}
		}
	}

	public Bounds Bounds => sr.bounds;


	private void SpawnNewLight()
	{
		//Debug.Log($"Camera rect: {myCamera.rect}");
		//Debug.Log($"Camera pixelRect: {myCamera.pixelRect}");
		//Debug.Log($"Camera pixelWidth: {myCamera.pixelWidth}");
		//Debug.Log($"Camera pixelHeight: {myCamera.pixelHeight}");
		//Debug.Log($"Camera scaledPixelHeight: {myCamera.scaledPixelHeight}");
		//Debug.Log($"Camera scaledPixelWidth: {myCamera.scaledPixelWidth}");
		//Debug.Log($"Camera transform.position.x: {myCamera.transform.position.x}");
		//Debug.Log($"Camera transform.position.y: {myCamera.transform.position.y}");
		//Debug.Log($"Camera transform.position.z: {myCamera.transform.position.z}");
		//Debug.Log($"Camera orthographicSize: {myCamera.orthographicSize}");
		//Debug.Log($"Camera sensorSize: {myCamera.sensorSize}");
		//Debug.Log($"Camera aspect: {myCamera.aspect}");
		//var parent = transform.parent;
		Camera myCamera = GameObject.FindGameObjectWithTag(Constants.MainCameraTagName).GetComponent<Camera>();
		Vector3 spawnPos = new (Random.Range(myCamera.transform.position.x- myCamera.orthographicSize * myCamera.aspect, myCamera.transform.position.x+ myCamera.orthographicSize * myCamera.aspect),
								Random.Range(myCamera.transform.position.y - myCamera.orthographicSize, myCamera.transform.position.y + myCamera.orthographicSize),
								0);

		Instantiate(discoLight, spawnPos, Quaternion.identity);
	}

	#region Cheats

	private void cheatNinja()
	{
		if (NinjaCheatActive)
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
			SpeedMultiplier = 1;
		}
		else
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
			SpeedMultiplier = 0.5f;
		}
		NinjaCheatActive = !NinjaCheatActive;
	}


	private void cheatDoge()
	{
		if (DogeCheatActive)
		{
			foreach (AnimalAI item in NPCDancers)
			{
				item.ResetSprite();
			}
		}
		else
		{
			foreach (AnimalAI item in NPCDancers)
			{
				item.SetSprite(dogeSprite);
			}
		}
		DogeCheatActive = !DogeCheatActive;
	}
	private void cheatSquidgame()
	{
		if (SquidgameCheatActive)
		{

		}
		else
		{

		}

		SquidgameCheatActive = !SquidgameCheatActive;
	}

	#endregion

}