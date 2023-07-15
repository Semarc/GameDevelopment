using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PointsScript : MonoBehaviour
{
	public bool Collected = false;

	[SerializeField] float PointHeight;
	private ParticleSystem ExplosionParticles;

	private void Awake()
	{
		transform.position = new Vector3(transform.position.x, PointHeight, transform.position.z);
		LevelManager.Instance.Points.Add(this);
		LevelManager.Instance.UpdateText();
		ExplosionParticles = GetComponentInChildren<ParticleSystem>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(Konstanten.PlayerTag) && Collected == false)
		{
			Collected = true;
			gameObject.SetActive(false);
			ExplosionParticles.Play();
			LevelManager.Instance.UpdateText();
			AudioScript.Instance.PlayPointCollectSound();
		}
	}
}