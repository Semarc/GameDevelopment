using System.Collections;

using UnityEngine;

public class EnemyShip : Ship
{
	[SerializeField] private GameObject ProjectilePrefabField;

	protected virtual GameObject ProjectilePrefab => ProjectilePrefabField;

	private Vector2 Direction = Vector2.up;

	[SerializeField] private int healthField;
	public override int Health { get => healthField; protected set => healthField = value; }



	[SerializeField] private float TimeBetweenAttacksField;
	protected virtual float TimeBetweenAttacks => TimeBetweenAttacksField;


	[SerializeField] private float speedField;
	protected override float speed => speedField;


	protected override void Awake()
	{
		base.Awake();
		StartCoroutine(EnemyShooting());
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(Konstanten.BoundryCollider))
		{
			Direction *= -1;
		}
	}

	private void Update()
	{
		rb.velocity = Direction * speed;
	}


	private IEnumerator EnemyShooting()
	{
		while (true)
		{
			Shoot();
			yield return new WaitForSeconds(TimeBetweenAttacks);
		}
	}

	protected virtual void Shoot()
	{
		HelperFunctions.InstantiateChildObject(gameObject, ProjectilePrefab);
		AudioScript.Instance.PlayShotSound();
	}

	public override void DoDamage(int Damage)
	{
		base.DoDamage(Damage);
		AudioScript.Instance.PlayEnemyHitSound();
	}

	protected override void Destroyed()
	{
		Debug.Log("Enemy Ship Destroyed");
		WaveManager.Instance.ReduceShipCount();
		AudioScript.Instance.PlayEnemyDestroyedSound();
		base.Destroyed();
	}
}