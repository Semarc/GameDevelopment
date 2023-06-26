using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	public static ParticleManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Debug.Log("Created ParticleManager");
			Instance = this;
		}
		else
		{
			Debug.LogWarning("Duplicate ParticleManager");
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	[SerializeField] private ParticleSystem playerExplosion;
	[SerializeField] private ParticleSystem enemyExplosion;
	public void PlayerExplosion(Vector2 Position)
	{
		DoParticles(playerExplosion, Position);
	}
	public void EnemyExplosion(Vector2 Position)
	{
		DoParticles(enemyExplosion, Position);
	}

	private void DoParticles(ParticleSystem system, Vector2 Position)
	{
		ParticleSystem particles = Instantiate(system, transform);
		particles.transform.position = Position;
		particles.Play();
		Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constant);
	}
}