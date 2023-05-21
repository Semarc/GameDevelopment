using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public static AudioScript Instance { get; private set; }

	[SerializeField] AudioClip SelectAudioClip;
	[SerializeField] AudioClip VorDerStation;
	[SerializeField] AudioClip InDerStation;
	[SerializeField] AudioClip NachDerStation;
	[SerializeField] AudioClip MainMenuMusic;

	AudioSource player;
	private void Start()
	{
		if(Instance == null)
		{
			Instance = this;
			player = GetComponent<AudioSource>();
		}
        else
		{
			Debug.LogWarning("Duplicate AudioScripts");
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	public void PlaySelectSound()
	{
		player.PlayOneShot(SelectAudioClip);
	}
	public void PlayVorDerStationSound()
	{
		PlayClip(VorDerStation);
	}
	public void PlayInDerStationSound()
	{
		PlayClip(InDerStation);
	}
	public void PlayNachDerStationSound()
	{
		PlayClip(NachDerStation);
	}
	public void PlayMainMenuMusicSound()
	{
		PlayClip(MainMenuMusic);
	}
	private void PlayClip(AudioClip clip)
	{
		player.clip = clip;
		player.Play();
	}
	public void SetVolume(int NewVolume)
	{
		player.volume = (float)NewVolume / 100;
	}
}
