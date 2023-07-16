using UnityEngine;

using System.Collections;

public class SwitchScript : MonoBehaviour
{
	[SerializeField] GameObject SpawnedObject;
	private bool Activated = false;

	private void Awake()
	{
		LevelManager.Instance.AreasToBeDisabled.Add(SpawnedObject);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (!Activated && collision.gameObject.CompareTag(Konstanten.PlayerTag))
		{
			Activated = true;
			SpawnedObject.SetActive(true);
			transform.position += Vector3.down * 0.15f;
			AudioScript.Instance.PlaySwitchSound();
		}
	}
}