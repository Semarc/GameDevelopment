using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public void Level1()
	{
		SceneManager.LoadScene(1);
	}

	public void Level2()
	{
		SceneManager.LoadScene(2);
	}
}
