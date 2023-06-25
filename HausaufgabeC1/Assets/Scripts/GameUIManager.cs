using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TMPro;

using UnityEngine;

public class GameUIManager : MonoBehaviour
{
	[SerializeField] TMP_Text GodModeText;
	[SerializeField] TextPopup PopupTextPrefab;

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

	public void SpawnHitText(Transform position, int damage)
	{
		TextPopup newPopup = Instantiate(PopupTextPrefab);
		newPopup.transform.position = position.position;
		newPopup.displayText = damage.ToString();
	}
}