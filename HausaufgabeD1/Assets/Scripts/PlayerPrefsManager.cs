using UnityEngine;

internal static class PlayerPrefsManager
{
	private const string Record = "Record";

	private static string GetSaveString(int Stage)
	{
		return Record + Stage.ToString();
	}
	public static void SaveRecordTime(int stage, float Time)
	{
		PlayerPrefs.SetFloat(GetSaveString(stage), Time);
		Debug.Log($"Saved RecordTime, Level {stage}, time {Time}");
	}

	public static bool TryGetRecordTime(int stage, out float Time)
	{
		float defaultValue = -1;
		Time = PlayerPrefs.GetFloat(GetSaveString(stage), defaultValue);

		Debug.Log($"Got RecordTime, Level {stage}, time {Time}");
		return !(Time == defaultValue);
	}
}