using System.Collections;

using UnityEngine;

public class LightsScript : MonoBehaviour
{
	private SpriteRenderer sr;
	private bool LightSwitchingEnabled = true;
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
			if (LightSwitchingEnabled)
			{
				sr.color = Random.ColorHSV();
				yield return new WaitForSeconds(Random.Range(4f, 5f));
			}
			else
			{
				yield return new WaitForSeconds(5);
			}
		}
	}
	public void SetLightColor(Color newColor)
	{
		LightSwitchingEnabled = false;
		sr.color = newColor;
	}
}
