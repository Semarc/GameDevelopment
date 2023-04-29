using UnityEngine;

using System;

public static class DanceMoves
{
	public static Action<Transform>[] AIDanceMoves = new Action<Transform>[]
	{
		DummyAIMove
	};
	public static Action<Transform>[] PlayerDanceMoves  = new Action<Transform>[]
	{
		DummyAIMove ,
		DummyPlayerMove
	};

	private static void DummyAIMove(Transform Dancer)
	{

	}
	private static void DummyPlayerMove(Transform Dancer)
	{

	}
}