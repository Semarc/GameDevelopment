using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class MyPlayerController : MonoBehaviour
{
	[SerializeField] private CubeSelectorScript[] CubeSelectors;
	[SerializeField] private Rigidbody CompanionCube;
	[SerializeField] private GameObject SpherePrefab;
	[SerializeField] private float BoxDistance;
	[SerializeField] private float ThrowForce;

	[SerializeField] private Material NightSkyBox;
	[SerializeField] private Material DaySkyBox;
	[SerializeField] private Light SpotLight;
	[SerializeField] private Light DirectionalLight;

	private const int CompanionCubeIndex = 4;

	private Rigidbody CurrentCube
	{
		get => _currentCube;
		set
		{
			if (_currentCube != null)
			{
				Debug.Log("Removed Old Cube");
				_currentCube.transform.parent = null;
				_currentCube.useGravity = true;
				_currentCube.isKinematic = false;
			}
			_currentCube = value;
			if (_currentCube != null)
			{
				Debug.Log("Added New Cube");
				_currentCube.transform.parent = Camera.main.transform;
				_currentCube.useGravity = false;
				_currentCube.isKinematic = true;
			}
		}
	}
	private Rigidbody _currentCube;
	int ChoosenBox;

	private void OnFlashlight(InputValue value)
	{
		SpotLight.enabled = !SpotLight.enabled;
		AudioScript.Instance.PlayFlashlightSound();
	}

	private void OnReturnMainMenu(InputValue value)
	{
		SceneManagerScript.Instance.LoadMainMenu();
	}

	private void OnDayTime(InputValue value)
	{
		Camera.main.GetComponent<Skybox>().material = DaySkyBox;
		DirectionalLight.transform.rotation = Quaternion.Euler(50, -30, 0);
	}

	private void OnNightTime(InputValue value)
	{
		Camera.main.GetComponent<Skybox>().material = NightSkyBox;
		DirectionalLight.transform.rotation = Quaternion.Euler(50 + 180, -30, 0);
	}

	private void OnThrowBall(InputValue value)
	{
		GameObject sphere = Instantiate(SpherePrefab, Camera.main.transform.position + Camera.main.transform.forward * BoxDistance, Camera.main.transform.rotation);
		sphere.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * ThrowForce);
		AudioScript.Instance.PlayThrowSound();
	}

	private void OnSpawnBox(InputValue value)
	{
		bool MousePressed = value.isPressed;

		if (MousePressed)
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

			if (Physics.Raycast(ray, out RaycastHit hit, 5) && hit.collider.gameObject.CompareTag(Konstanten.BoxTag))
			{
				CurrentCube = hit.collider.gameObject.GetComponent<Rigidbody>();
			}
			else
			{
				if (ChoosenBox == CompanionCubeIndex)
				{
					CurrentCube = CompanionCube;
					CurrentCube.transform.position = Camera.main.transform.position + Camera.main.transform.rotation * (BoxDistance * Vector3.forward);
				}
				else
				{
					CurrentCube = Instantiate(CubeSelectors[ChoosenBox].cubePrefab, Camera.main.transform).GetComponent<Rigidbody>();
				}
			}
			CurrentCube.rotation = Camera.main.transform.rotation;
			CurrentCube.position = Camera.main.transform.position + Camera.main.transform.rotation * (BoxDistance * Vector3.forward);
		}
		else
		{
			CurrentCube = null;
		}
	}

	private void OnChooseBox(InputValue value)
	{
		int temp =  Mathf.FloorToInt(value.Get<float>());
		if (temp > 0)
		{
			ChoosenBox = temp - 1;
			Debug.Log("Choose Box " + ChoosenBox);
			foreach (var item in CubeSelectors)
			{
				item.ImageEnabled = false;
			}
			CubeSelectors[ChoosenBox].ImageEnabled = true;
		}
	}


	private void FixedUpdate()
	{
		if (CurrentCube != null)
		{
			CurrentCube.rotation = Camera.main.transform.rotation;
			CurrentCube.position = Camera.main.transform.position + Camera.main.transform.forward * BoxDistance;
		}
	}

	private void Awake()
	{
		CubeSelectors[ChoosenBox].ImageEnabled = true;
	}

	private void Start()
	{
		OnDayTime(null);
	}
}