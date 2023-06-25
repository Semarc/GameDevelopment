using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.VisualScripting;

using UnityEngine;

public static class SaveManager
{
	private const string HighScoreName = "HighScore";
	public static void SaveHighScore(int HighScore)
	{
		PlayerPrefs.SetInt(HighScoreName, Math.Max(HighScore, GetHighScore()));
		PlayerPrefs.Save();
	}
	public static int GetHighScore()
	{
		return PlayerPrefs.GetInt(HighScoreName);
	}
}