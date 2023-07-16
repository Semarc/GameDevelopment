using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public static AudioScript Instance { get; private set; }


	[SerializeField] AudioClip Flashlight;
	[SerializeField] AudioClip Throw;

	[SerializeField] AudioClip Music;
	[SerializeField] AudioClip MainMenuMusic;

	AudioSource player;
	private void Awake()
	{
		if (Instance == null)
		{
			Debug.Log("Created AudioScript");
			Instance = this;
			player = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Debug.LogWarning("Duplicate AudioScript");
			Destroy(gameObject);
		}
	}

	public void PlayThrowSound()
	{
		player.PlayOneShot(Throw);
	}
	public void PlayFlashlightSound()
	{
		player.PlayOneShot(Flashlight);
	}

	public void PlayMusic()
	{
		PlayClip(Music);
	}
	public void PlayMainMenuMusic()
	{
		PlayClip(MainMenuMusic);
	}
	public void StopMusic()
	{
		player.Stop();
	}



	private void PlayClip(AudioClip clip)
	{
		player.Stop();
		player.clip = clip;
		player.Play();
	}
	public void SetVolume(float NewVolume)
	{
		player.volume = NewVolume;
	}
}