using UnityEngine;

public class AudioScript : MonoBehaviour
{
	public static AudioScript Instance { get; private set; }

	[SerializeField] AudioClip PlayerHit;
	[SerializeField] AudioClip GodModeActivated;
	[SerializeField] AudioClip EnemyHit;
	[SerializeField] AudioClip EnemyDestroyed;
	[SerializeField] AudioClip Shot;
	[SerializeField] AudioClip Music;

	AudioSource player;
	private void Awake()
	{
		if (Instance == null)
		{
			Debug.Log("Created AudioScript");
			Instance = this;
			player = GetComponent<AudioSource>();
		}
		else
		{
			Debug.LogWarning("Duplicate AudioScript");
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	public void PlayPlayerHitSound()
	{
		player.PlayOneShot(PlayerHit);
	}
	public void PlayGodModeActivatedSound()
	{
		player.PlayOneShot(GodModeActivated);
	}
	public void PlayEnemyHitSound()
	{
		player.PlayOneShot(EnemyHit);
	}
	public void PlayEnemyDestroyedSound()
	{
		player.PlayOneShot(EnemyDestroyed);
	}
	public void PlayShotSound()
	{
		player.PlayOneShot(Shot);
	}
	public void PlayMusic()
	{
		PlayClip(Music);
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