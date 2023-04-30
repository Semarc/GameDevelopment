using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

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
	private bool DrunkCheatActive = false;
	private bool PusheenCheatActive = false;

	public bool IsDancing { get; set; } = false;
	string enteredKeys = string.Empty;

	private Dictionary<string, Action> cheatCodes;

	[SerializeField] private GameObject discoLight;
	[SerializeField] private Sprite dogeSprite;
	[SerializeField] private Sprite PusheenSprite;
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
			{ "DRUNK", cheatDrunk},
			{ "PUSHEEN", cheatPusheen},
		};

		NPCDancers = HelperFunctions.GetComponentsFromObjects<AnimalAI>(Constants.NPCDancerTagName);
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



		if (Input.GetKeyDown(KeyCode.F) && !SquidgameCheatActive)
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

			if (SquidgameCheatActive && moveVector.magnitude > 0)
			{
				SquidgameCheatActive = false;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
			}

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
			SpeedMultiplier *= 2;
		}
		else
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
			SpeedMultiplier *= 0.5f;
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
		SquidgameCheatActive = true;

		LightsScript[] discoLights = HelperFunctions.GetComponentsFromObjects<LightsScript>(Constants.DiscoLightsTagName);

		StartCoroutine(squidGameLights());

		IEnumerator squidGameLights()
		{
			bool RedLight = false;
			while (SquidgameCheatActive)
			{

				if (RedLight)
				{
					SetAllLightColors(Color.red);
					SetAllRedLights();
					yield return new WaitForSeconds(Random.Range(4, 8));
				}
				else
				{
					SetAllRedLights();
					SetAllLightColors(Color.green);
					yield return new WaitForSeconds(Random.Range(2, 6));
				}
				RedLight = !RedLight;
			}

			void SetAllLightColors(Color newColor)
			{
				foreach (LightsScript item in discoLights)
				{
					item.SetLightColor(newColor);
				}
			}
			void SetAllRedLights()
			{
				foreach (AnimalAI item in NPCDancers)
				{
					item.RedLight = RedLight;
				}
			}
		}
	}

	private void cheatDrunk()
	{
		DrunkCheatActive = !DrunkCheatActive;

		if (DrunkCheatActive)
		{
			StartCoroutine(DrunkCoroutine());
		}
		IEnumerator DrunkCoroutine()
		{
			SpeedMultiplier *= 0.75f;
			Quaternion CurrentRotation = Quaternion.identity;
			while (DrunkCheatActive)
			{
				CurrentRotation = Quaternion.Euler(0, 0, CurrentRotation.eulerAngles.z + 180 * Time.deltaTime * Random.Range(0.5f, 2f));
				transform.position += CurrentRotation * Vector3.up * possibleSpeeds[speedIndex] * SpeedMultiplier * Time.deltaTime;
				yield return null;
			}
			SpeedMultiplier *= 1f / 0.75f;
		}
	}

	private void cheatPusheen()
	{
		if (PusheenCheatActive)
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
				item.SetSprite(PusheenSprite);
			}			
		}
		PusheenCheatActive = !PusheenCheatActive;
	}
	#endregion
}