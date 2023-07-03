using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class GoalScript : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(Konstanten.PlayerTag) && PointManager.Instance.GoalUnlocked)
		{
			Victory();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F4))
		{
			Victory();
		}
	}

	private void Victory()
	{
		AudioScript.Instance.PlayVictorySound();
	}
}