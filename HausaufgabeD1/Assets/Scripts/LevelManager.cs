using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance;

	public List<PointsScript> Points = new();
	public int Total => Points.Count;
	public int Collected => Points.Where(x => x.Collected).Count();
	public bool GoalUnlocked => Collected == Total;
	public bool Victory { get; set; } = false;

	public List<GameObject> AreasToBeDisabled = new List<GameObject>();

	[SerializeField] private TMP_Text PointsText;


	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
			UpdateText();
			AudioScript.Instance?.PlayMusic();
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
			Destroy(this);
		}
	}

	public void UpdateText()
	{
		PointsText.text = $"{Collected}/{Total}";
		PointsText.color = GoalUnlocked ? Color.green : Color.red;
	}

	private void Start()
	{
		Debug.Log("LevelManager Start");
		foreach (var item in AreasToBeDisabled)
		{
			Debug.Log("Disabling " + item.name);
			item.SetActive(false);
		}
	}
}