using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		Vector3 moveVector = Vector3.zero;

		// Get input and save state in moveVector
		if (Input.GetKey(KeyCode.W)) moveVector.y = 1;
		if (Input.GetKey(KeyCode.A)) moveVector.x = -1;
		if (Input.GetKey(KeyCode.S)) moveVector.y = -1;
		if (Input.GetKey(KeyCode.D)) moveVector.x = 1;

		moveVector.Normalize();

		transform.position += Time.deltaTime * 20f * moveVector;
	}
}
