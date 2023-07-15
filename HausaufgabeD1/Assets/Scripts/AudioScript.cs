using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public static AudioScript Instance { get; private set; }

	[SerializeField] AudioClip Victory;
	[SerializeField] AudioClip CollectPoint;
	[SerializeField] AudioClip Jump;
	[SerializeField] AudioClip Switch;

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
	public void PlayVictorySound()
	{
		player.PlayOneShot(Victory);
	}
	public void PlayPointCollectSound()
	{
		player.PlayOneShot(CollectPoint);
	}
	public void PlayJumpSound()
	{
		player.PlayOneShot(Jump);
	}
	public void PlaySwitchSound()
	{
		player.PlayOneShot(Switch);
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