using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
	private enum Jumpcount
	{
		None = 0,
		One,
		Two,
	}

	public static Material BallTexture;

	private Vector3 moveDirection;
	private bool godMode = false;
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;

	[SerializeField] private float CameraBackOffset;
	[SerializeField] private float CameraHeight;
	private ParticleSystem GroundParticles;



	private Rigidbody rb;

	private bool jump;
	private bool moving;
	private bool touchingGround;

	private Jumpcount jumpcount = Jumpcount.Two;

	private Camera cam;

	void Awake()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
		Renderer renderer = GetComponent<Renderer>();
		if (BallTexture != null)
		{
			renderer.material = BallTexture;
		}
		GroundParticles = GetComponentInChildren<ParticleSystem>();
	}

	#region Inputs

	private void OnMove(InputValue movementValue)
	{
		moveDirection = movementValue.Get<Vector3>().normalized;
		moving = moveDirection != Vector3.zero;
	}
	private void OnGodMode(InputValue godModeInputValue)
	{
		if (godModeInputValue.Get<float>() != 0)
		{
			godMode = !godMode;

			Debug.Log("Toggeled Godmode" + godMode);

			rb.isKinematic = godMode;
			rb.useGravity = !godMode;
		}
	}

	private void OnJump(InputValue jumpValue)
	{
		if (jumpcount > Jumpcount.None && jumpValue.Get<float>() != 0)
		{
			AudioScript.Instance.PlayJumpSound();
			Debug.Log("Jumped");
			jump = true;
			jumpcount--;
		}
	}

	private void OnReturnMainMenu()
	{
		SceneManagerScript.Instance.LoadMainMenu();
	}


	#endregion

	private void FixedUpdate()
	{
		if (!godMode)
		{
			moveDirection.y = 0;
			rb.AddForce(moveDirection * speed);
			if (jump)
			{
				rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
				rb.AddForce(Vector3.up * jumpForce);
				jump = false;
			}
		}
		else
		{
			transform.position += speed * Time.fixedDeltaTime * moveDirection;
			jump = false;
		}
	}

	private void Update()
	{
		cam.transform.SetPositionAndRotation(new Vector3(transform.position.x, CameraHeight, transform.position.z - CameraBackOffset), Quaternion.Euler(30, 0, 0));

		if (transform.position.y <= -20)
		{
			SceneManagerScript.Instance.ReloadScene();
		}
		GroundParticles.gameObject.SetActive(moving && touchingGround);
		GroundParticles.transform.SetPositionAndRotation(transform.position + Vector3.down * 0.45f, Quaternion.Euler(90, 0, 0));
	}


	private void OnCollisionEnter(Collision collision)
	{
		//ContactPoint[] temp = new ContactPoint[collision.contactCount];
		//collision.GetContacts(temp);
		//Vector3[] temp2 = temp.Select(x => x.point).ToArray();

		//Vector3 meanVector = Helperfunctions.GetMeanVector(temp2);

		jumpcount = Jumpcount.Two;
		touchingGround = true;


		if (collision.gameObject.CompareTag(Konstanten.GoalTag) && LevelManager.Instance.GoalUnlocked && !LevelManager.Instance.Victory)
		{
			LevelManager.Instance.Victory = true;
			AudioScript.Instance.StopMusic();
			AudioScript.Instance.PlayVictorySound();
			StartCoroutine(VictoryCo());
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		touchingGround = false;
	}

	IEnumerator VictoryCo()
	{
		yield return new WaitForSeconds(4);
		SceneManagerScript.Instance.LoadMainMenu();
	}
}