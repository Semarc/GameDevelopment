using System.Collections;
using System;
using System.Collections.Generic;

using UnityEngine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] Collider2D firstDoor;
	[SerializeField] Collider2D secondDoor;
	[SerializeField] Vector2 firstDoorDirection;
	[SerializeField] Vector2 secondDoorDirection;

	// Start is called before the first frame update
	void Start()
	{
		DoorScriptInner firstDoorScript = firstDoor.gameObject.AddComponent<DoorScriptInner>();
		DoorScriptInner secondDoorScript = secondDoor.gameObject.AddComponent<DoorScriptInner>();
		firstDoorScript.Other = secondDoorScript;
		secondDoorScript.Other = firstDoorScript;
		firstDoorScript.Direction = firstDoorDirection;
		secondDoorScript.Direction = secondDoorDirection;
	}

	private class DoorScriptInner : MonoBehaviour
	{
		public DoorScriptInner Other;
		public Vector2 Direction;
		private bool WasPorted;
		private Collider2D OwnCollider;

		private void Awake()
		{
			OwnCollider = GetComponent<Collider2D>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (Other.WasPorted)
			{
				while (OwnCollider.bounds.Contains(collision.transform.position))
				{
					collision.transform.position += (Vector3)(0.1f * Direction);
				}
			}
			else if (collision.gameObject.CompareTag(Konstanten.PlayerTag))
			{
				WasPorted = true;
				collision.transform.position = Other.transform.position;
			}
		}
		private void OnTriggerStay2D(Collider2D collision)
		{
			if (Other.WasPorted)
			{
				if (OwnCollider.bounds.Intersects(collision.bounds))
				{
					collision.transform.position += (Vector3)(0.1f * Direction);
				}
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			Other.WasPorted = false;
		}
	}
}