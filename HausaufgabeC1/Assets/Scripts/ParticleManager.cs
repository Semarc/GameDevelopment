using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		ParticleSystem particles = Instantiate(enemyExplosion, Position, Quaternion.identity);
		particles.Play();
	}
	public void EnemyExplosion(Vector2 Position)
	{
		ParticleSystem particles = Instantiate(enemyExplosion, Position, Quaternion.identity);
		particles.Play();
	}
}
