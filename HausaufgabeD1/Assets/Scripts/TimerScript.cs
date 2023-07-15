using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
	[SerializeField] private TMP_Text TimeText;

	private string recordTime = string.Empty;
	private float recordTimeFloat;
	private bool SavedRecordTime;

	private void Awake()
	{
		if (PlayerPrefsManager.TryGetRecordTime(SceneManager.GetActiveScene().buildIndex, out recordTimeFloat))
		{
			recordTime = recordTimeFloat.ToString("F2");
		}
		else
		{
			recordTimeFloat = float.MaxValue;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!LevelManager.Instance.Victory)
		{
			TimeText.text = $"{Time.timeSinceLevelLoad:F2}{Environment.NewLine}{recordTime}";
		}
		else if (!SavedRecordTime)
		{
			SavedRecordTime = true;
			if (recordTimeFloat > Time.timeSinceLevelLoad)
			{
				PlayerPrefsManager.SaveRecordTime(SceneManager.GetActiveScene().buildIndex, Time.timeSinceLevelLoad);
			}
		}
	}
}
