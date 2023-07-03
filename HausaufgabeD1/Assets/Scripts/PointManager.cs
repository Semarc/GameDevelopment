using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
	public static PointManager Instance;

	public List<PointsScript> Points = new();
	public int Total => Points.Count;
	public int Collected => Points.Where(x => x.Collected).Count();
	public bool GoalUnlocked => Collected == Total;

	[SerializeField] private TMP_Text PointsText;


	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
			UpdateText();
		}
		else
		{
			Debug.Log("Duplicate PointManager");
			Destroy(this);
		}
	}

	private void SceneManager_sceneUnloaded(Scene arg0)
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void UpdateText()
	{
		PointsText.text = $"{Collected}/{Total}";
		PointsText.color = GoalUnlocked ? Color.green : Color.red;
	}
}