using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class AnimalAI : MonoBehaviour, IDancer
{
	public bool IsDancing { get; set; } = false;

	private Sprite OriginalSprite;
	private SpriteRenderer sr;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Dance());
		sr = GetComponent<SpriteRenderer>();
		OriginalSprite = sr.sprite;
	}

	private IEnumerator Dance()
	{
		//Start Dancing at random Times after Program Start
		yield return new WaitForSeconds(Random.Range(1f, 20f));
		while (true)
		{
			if (!IsDancing)
			{
				IsDancing = true;
				StartCoroutine(DanceMoves.AIDanceMoves[Random.Range(0, DanceMoves.AIDanceMoves.Length - 1)](this));
				yield return new WaitForSeconds(Random.Range(5f, 10f));
			}
			else
			{
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
	public void ResetSprite()
	{
		sr.sprite = OriginalSprite;
	}
	public void SetSprite(Sprite newSprite)
	{
		sr.sprite = newSprite;
	}
}