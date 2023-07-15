using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SwitchScript : MonoBehaviour
{
	[SerializeField] Collider SpawnedObject;
	private bool Activated = false;

	private void Awake()
	{
		SpawnedObject.gameObject.SetActive(false);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (!Activated && collision.gameObject.CompareTag(Konstanten.PlayerTag))
		{
			Activated = true;
			SpawnedObject.gameObject.SetActive(true);
			transform.position += Vector3.down * 0.15f;
			AudioScript.Instance.PlaySwitchSound();
		}
	}
}