using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] private Text HighScoreText;

	private void Start()
	{
		HighScoreText.text = $"HIGHSCORE: {SaveManager.GetHighScore()}";
	}

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
