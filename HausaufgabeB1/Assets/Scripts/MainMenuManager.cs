using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	private void Start()
	{
		AudioScript.Instance.PlayMainMenuMusicSound();
	}
	public void GoToGame()
	{
		SceneManager.LoadScene(1);
	}
}
