using UnityEngine;

public class StandardEnemyProjectile : ProjectileScript
{

	protected override int Damage => 2;

	[SerializeField] private Vector2 MoveVectorField;
	protected override Vector2 MoveVector => MoveVectorField;

	protected override string[] HostileTags => new[] { Konstanten.PlayerShipTag };
}