using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

internal static class PlayerPrefsManager
{
	private const string Record = "Record";

	private static string GetSaveString(int Stage)
	{
		return Record + Stage.ToString();
	}
	public static void SaveRecordTime(int Stage, float Time)
	{
		PlayerPrefs.SetFloat(GetSaveString(Stage), Time);
	}

	public static bool TryGetRecordTime(int stage, out float Time)
	{
		float defaultValue = -1;
		Time = PlayerPrefs.GetFloat(GetSaveString(stage), defaultValue);

		return !(Time == defaultValue);
	}
}