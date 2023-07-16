using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
	public static SceneManagerScript Instance { get; private set; }

	void Awake()
	{
		if (Instance == null)
		{
			Debug.Log("Created SceneManagerScript");
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Debug.LogWarning("Duplicate SceneManagerScript");
			Destroy(gameObject);
		}
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadSceneAsync(0);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	public void LoadLevel(int levelNumber)
	{
		SceneManager.LoadSceneAsync(levelNumber + 1);
	}
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}