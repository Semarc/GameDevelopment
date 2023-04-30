using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	public Transform target;
	public float smooth= 5.0f;
	void Update()
	{
		float temp = transform.position.z;

		PlayerInputs playerMovement = target.GetComponent<PlayerInputs>();

		transform.position = Vector3.Lerp(
			transform.position, playerMovement.Bounds.center,
			Time.deltaTime * smooth);
		transform.position = new Vector3(transform.position.x, transform.position.y, temp);
	}
}