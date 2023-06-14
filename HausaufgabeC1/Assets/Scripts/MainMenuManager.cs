using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < 4; i++)
		{
			if (Input.GetMouseButtonDown(i))
			{
				SceneManager.LoadScene(1);
			}
		}
	}
}
