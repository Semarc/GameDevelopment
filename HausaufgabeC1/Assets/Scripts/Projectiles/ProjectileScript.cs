using UnityEngine;

public abstract class ProjectileScript : MonoBehaviour
{
	Rigidbody2D rb;

	protected abstract string[] HostileTags { get; }
	protected abstract int Damage { get; }

	protected abstract Vector2 MoveVector { get; }

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("H: " + string.Join(", ", HostileTags) + Environment.NewLine + "C: " + collision.gameObject.tag);
		foreach (string item in HostileTags)
		{
			if (collision.gameObject.CompareTag(item))
			{
				if (collision.TryGetComponent<Ship>(out Ship collidedShip))
				{
					Debug.Log($"Do Damage {Damage}");
					collidedShip.DoDamage(Damage);
					Destroy(gameObject);
				}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(Konstanten.BoundryCollider))
		{
			Destroy(gameObject);
		}
	}

	protected virtual void FixedUpdate()
	{
		Move();
	}


	private void Move()
	{
		rb.velocity = MoveVector;
	}
}