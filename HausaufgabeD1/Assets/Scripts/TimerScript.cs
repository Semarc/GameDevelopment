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

	private void Awake()
	{
		if (PlayerPrefsManager.TryGetRecordTime(SceneManager.GetActiveScene().buildIndex, out float recordTimeFloat))
		{
			recordTime = recordTimeFloat.ToString("F2");
		}
	}

	// Update is called once per frame
	void Update()
	{
		TimeText.text = $"{Time.timeSinceLevelLoad:F2}{Environment.NewLine}{recordTime}";
	}
}
