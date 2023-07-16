using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PointsScript : MonoBehaviour
{
	public bool Collected = false;

	[SerializeField] float PointHeight;
	private ParticleSystem ExplosionParticles;
	private Renderer rend;

	private void Awake()
	{
		transform.position = transform.position + Vector3.up * 1000;

		if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
		{
			transform.position = hitInfo.point + Vector3.up * PointHeight;
		}
		else
		{
			transform.position = transform.position - Vector3.up * 1000;
			Debug.LogWarning("Points without ground at " + transform.position);
		}

		//transform.position = new Vector3(transform.position.x, PointHeight, transform.position.z);
		LevelManager.Instance.Points.Add(this);
		LevelManager.Instance.UpdateText();
		ExplosionParticles = GetComponentInChildren<ParticleSystem>();
		rend = GetComponent<Renderer>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(Konstanten.PlayerTag) && Collected == false)
		{
			Collected = true;
			ExplosionParticles.Play();
			rend.enabled = false;
			LevelManager.Instance.UpdateText();
			AudioScript.Instance.PlayPointCollectSound();
		}
	}
}