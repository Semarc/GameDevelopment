using System.Collections;
using System.Collections.Generic;

using TMPro;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
	static int Volume = 50;

	[SerializeField] private GameObject WalkThroughPanel;
	[SerializeField] private GameObject OptionsPanel;
	[SerializeField] private Slider VolumeSlider;
	[SerializeField] private TMP_Text VolumeText;

	private void Start()
	{
		VolumeSlider.onValueChanged.AddListener(SetVolume);
		SetVolume(Volume);
		VolumeSlider.value = Volume;
	}

	public void ToggleOptions()
	{
		OptionsPanel.SetActive(!OptionsPanel.activeSelf);
		if (!OptionsPanel.activeSelf)
		{
			WalkThroughPanel.SetActive(false);
		}
	}
	public void ToggleWalkthrough()
	{
		WalkThroughPanel.SetActive(!WalkThroughPanel.activeSelf);
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	private void SetVolume(float NewVolume)
	{
		Volume = (int)NewVolume;
		VolumeText.text = Volume.ToString();
		AudioScript.Instance.SetVolume(Volume);
	}
}