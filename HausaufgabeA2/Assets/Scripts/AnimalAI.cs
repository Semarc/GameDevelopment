using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class AnimalAI : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Dance());
	}

	private IEnumerator Dance()
	{
		while (true)
		{
			DanceMoves.AIDanceMoves[Random.Range(0, DanceMoves.AIDanceMoves.Length - 1)](transform);
			yield return new WaitForSeconds(Random.Range(1f, 4f));
		}
	}

}
