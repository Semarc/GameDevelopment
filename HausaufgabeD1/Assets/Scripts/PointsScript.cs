using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PointsScript : MonoBehaviour
{
	public bool Collected = false;

	[SerializeField] float PointHeight;

	private void Awake()
	{
		transform.position = new Vector3(transform.position.x, PointHeight, transform.position.z);
		LevelManager.Instance.Points.Add(this);
		LevelManager.Instance.UpdateText();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(Konstanten.PlayerTag) && Collected == false)
		{
			Collected = true;
			gameObject.SetActive(false);
			LevelManager.Instance.UpdateText();
			AudioScript.Instance.PlayPointCollectSound();
		}
	}
}