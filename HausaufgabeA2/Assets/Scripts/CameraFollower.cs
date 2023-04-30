using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	public Transform target;
	public float smooth= 5.0f;
	SpriteRenderer BackgroundSR;

	void Awake()
	{
		BackgroundSR = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		float temp = transform.position.z;

		PlayerInputs playerMovement = target.GetComponent<PlayerInputs>();

		transform.position = Vector3.Lerp(
			transform.position, playerMovement.Bounds.center,
			Time.deltaTime * smooth);
		transform.position = new Vector3(transform.position.x, transform.position.y, temp);

		if (Input.GetKeyDown(KeyCode.O))
		{
			Color.RGBToHSV(BackgroundSR.color, out float H, out float S, out float V);
			BackgroundSR.color = Color.HSVToRGB(H, S, V - 0.1f);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			Color.RGBToHSV(BackgroundSR.color, out float H, out float S, out float V);
			BackgroundSR.color = Color.HSVToRGB(H, S, V + 0.1f);
		}
	}
}