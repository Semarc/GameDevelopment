using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LightsScript : MonoBehaviour
{
	SpriteRenderer sr;
	// Start is called before the first frame update
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		StartCoroutine(ChangeLightColor());
	}
	private IEnumerator ChangeLightColor()
	{
		yield return new WaitForSeconds(Random.Range(0f, 2.5f));
		while (true)
		{
			sr.color = Random.ColorHSV();
			yield return new WaitForSeconds(Random.Range(4f, 5f));
		}
	}
}
