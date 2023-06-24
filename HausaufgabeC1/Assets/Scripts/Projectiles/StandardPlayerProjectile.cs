using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StandardPlayerProjectile : ProjectileScript
{

	protected override int Damage => 10;

	protected override Vector2 MoveVector => new(10f, 0);

	protected override string[] HostileTags => new[] { Konstanten.EnemyShipTag };
}