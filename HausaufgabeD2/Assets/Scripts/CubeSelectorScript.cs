using UnityEngine;
using UnityEngine.UI;

public class CubeSelectorScript : MonoBehaviour
{
	public GameObject cubePrefab;

	private Image image;

	public bool ImageEnabled { get => image.enabled; set => image.enabled = value; }

	private void Awake()
	{
		image = GetComponent<Image>();
		image.enabled = false;
	}
}