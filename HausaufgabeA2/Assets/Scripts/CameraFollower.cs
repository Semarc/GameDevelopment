using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	public Transform target;
	public float smooth= 5.0f;
	void Update()
	{
		float temp = transform.position.z;

		PlayerMovement playerMovement =    target.GetComponent<PlayerMovement>();

		transform.position = Vector3.Lerp(
			transform.position, playerMovement.GetAllChildBounds().center,
			Time.deltaTime * smooth);
		transform.position = new Vector3(transform.position.x, transform.position.y, temp);
	}
}