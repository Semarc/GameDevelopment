using System.Collections;

using TMPro;

using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextPopup : MonoBehaviour
{
	public string displayText;

	// Start is called before the first frame update
	void Start()
	{
		TMP_Text tmp_text = GetComponent<TMP_Text>();
		tmp_text.text = displayText;
		StartCoroutine(MoveAndFadeTextCo(tmp_text));
		//tmp_text.DOFade(0f, 0.7f);
		//transform.DOMove(transform.position + Vector3.up, 0.75f).OnComplete(() => Destroy(gameObject));
	}

	IEnumerator MoveAndFadeTextCo(TMP_Text tmp_text)
	{
		while (tmp_text.alpha > 0)
		{
			tmp_text.alpha -= Time.deltaTime;
			tmp_text.transform.position = transform.position + 50 * Time.deltaTime * Vector3.up;
			yield return null;
		}
		Destroy(gameObject);
	}
}