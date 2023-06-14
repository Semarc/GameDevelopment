using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WaveManager : MonoBehaviour
{
	private int waveCount = 0;

	private void NextWave()
	{
		waveCount++;
	}
}