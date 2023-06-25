using TMPro;

using UnityEngine;

public class GameUIManager : MonoBehaviour
{
	[SerializeField] TMP_Text GodModeText;
	[SerializeField] TextPopup PopupTextPrefab;
	[SerializeField] Canvas myCanvas;

	public static GameUIManager Instance { get; private set; }

	private void Awake()
	{
		Destroy(Instance);
		Instance = this;
	}

	public void ToogleGodmodText(bool Shown)
	{
		GodModeText.gameObject.SetActive(Shown);
	}
}