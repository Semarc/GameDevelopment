using UnityEngine;

public abstract class Ship : MonoBehaviour
{
	public abstract int Health { get; protected set; }
	protected abstract float speed { get; }

	protected Rigidbody2D rb;

	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	public virtual void DoDamage(int Damage)
	{
		Health -= Damage;
		if (Health <= 0)
		{
			Destroyed();
		}
	}
	protected virtual void Destroyed()
	{
		ParticleManager.Instance.EnemyExplosion(transform.position);
		Destroy(gameObject);
	}
}