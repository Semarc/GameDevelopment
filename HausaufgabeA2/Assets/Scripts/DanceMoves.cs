using UnityEngine;

using System;
using System.Collections;

public static class DanceMoves
{
	public static Func<Transform, IEnumerator>[] AIDanceMoves = new Func<Transform, IEnumerator>[]
	{
		DummyAIMove
	};
	public static Func<Transform, IEnumerator>[] PlayerDanceMoves  = new Func<Transform, IEnumerator>[]
	{
		DummyAIMove ,
		DummyPlayerMove
	};

	private static IEnumerator DummyAIMove(Transform Dancer)
	{
		var temp = Time.deltaTime;
		yield return null;
	}
	private static IEnumerator DummyPlayerMove(Transform Dancer)
	{
		yield return null;
	}
}