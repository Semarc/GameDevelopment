using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public static AudioScript Instance { get; private set; }

	[SerializeField] AudioClip Victory;
	[SerializeField] AudioClip Music;

	AudioSource player;
	private void Awake()
	{
		if (Instance == null)
		{
			Debug.Log("Created AudioScript");
			Instance = this;
			player = GetComponent<AudioSource>();
			PlayMusic();
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
	public void PlayMusic()
	{
		PlayClip(Music);
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