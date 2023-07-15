using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	private void Awake()
	{
		AudioScript.Instance.PlayMainMenuMusic();
	}
}