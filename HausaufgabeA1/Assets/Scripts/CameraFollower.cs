using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	public static Transform target;
	public float smooth= 5.0f;
	void Update()
	{
		var temp = transform.position.z;

		var playerMovement =    target.GetComponent<PlayerMovement>();

		transform.position = Vector3.Lerp(
			transform.position, playerMovement.GetAllChildBounds().center,
			Time.deltaTime * smooth);
		transform.position = new Vector3(transform.position.x, transform.position.y, temp);
	}
}