using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class BallController : MonoBehaviour
{
	private Vector3 moveDirection;
	private bool godMode = false;
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;

	[SerializeField] private float CameraBackOffset;
	[SerializeField] private float CameraHeight;

	private Rigidbody rb;

	private bool jump;

	private Camera cam;

	void Awake()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
	}

	#region Inputs

	private void OnMove(InputValue movementValue)
	{
		moveDirection = movementValue.Get<Vector3>().normalized;
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
		if (jumpValue.Get<float>() != 0)
		{
			Debug.Log("Jumped");
			jump = true;
		}
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
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		}
	}
}