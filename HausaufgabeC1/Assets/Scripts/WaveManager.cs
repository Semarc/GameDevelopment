using System.Collections.Generic;

using UnityEngine;

public class WaveManager : MonoBehaviour
{
	public static WaveManager Instance { get; private set; }

	[SerializeField] private List<GameObject> shipPrefabs = new ();
	[SerializeField] private List<GameObject> bossPrefabs = new ();

	private void Awake()
	{
		Destroy(Instance);
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	private class SpawnRange
	{
		public Vector2 TopPoint;
		public Vector2 BottomPoint;
		public SpawnRange(Vector2 topPoint, Vector2 bottomPoint)
		{
			TopPoint = topPoint;
			BottomPoint = bottomPoint;
		}

		public override string ToString()
		{
			return $"{TopPoint} {BottomPoint}";
		}
	}

	private SpawnRange[] spawnRanges;

	private int waveCount = 0;

	private int shipCount;

	private void Start()
	{
		Camera cam = Camera.main;

		Vector2 bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
		Vector2 topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
		Vector2 topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
		Vector2 bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

		Vector2 LeftRightDistance = bottomRight - bottomLeft;
		Vector2 TopBottomDistance = topLeft - bottomLeft;

		//Debug.Log("LeftRightDistance: " + LeftRightDistance);
		//Debug.Log("TopBottomDistance: " + TopBottomDistance);

		spawnRanges = new SpawnRange[] { new SpawnRange(bottomLeft + LeftRightDistance * 0.6f + TopBottomDistance * 0.2f, bottomLeft + LeftRightDistance * 0.6f + TopBottomDistance * 0.8f),
										 new SpawnRange(bottomLeft + LeftRightDistance * 0.75f + TopBottomDistance * 0.2f, bottomLeft + LeftRightDistance * 0.75f + TopBottomDistance * 0.8f),
										 new SpawnRange(bottomLeft + LeftRightDistance * 0.9f + TopBottomDistance * 0.2f, bottomLeft + LeftRightDistance * 0.9f + TopBottomDistance * 0.8f)};
		//string temp = "SpawnRanges: ";
		//foreach (SpawnRange item in spawnRanges)
		//{
		//	temp += item.ToString() + ", ";
		//}
		//Debug.Log(temp);

		NextWave();
	}

	private void NextWave()
	{
		Debug.Log("Next Wave");

		waveCount++;
		SaveManager.SaveHighScore(waveCount);

		if (waveCount % 5 != 0)
		{
			Random.InitState(waveCount);
			for (int i = 0; i < waveCount; i++)
			{
				Vector3 position = new(spawnRanges[Random.Range(0, spawnRanges.Length)].TopPoint.x, Random.Range(spawnRanges[0].TopPoint.y, spawnRanges[0].BottomPoint.y));
				GameObject shiptype = shipPrefabs[ Random.Range(0, shipPrefabs.Count)];

				GameObject newShip = Instantiate(shiptype);
				newShip.transform.position = position;
			}
			shipCount = waveCount;
		}
		else
		{
			int BossWaveCount = waveCount/5;
			Random.InitState(waveCount);
			for (int i = 0; i < BossWaveCount; i++)
			{
				Vector3 position = new(spawnRanges[Random.Range(0, spawnRanges.Length)].TopPoint.x, Random.Range(spawnRanges[0].TopPoint.y, spawnRanges[0].BottomPoint.y));
				GameObject shiptype = bossPrefabs[Random.Range(0, bossPrefabs.Count)];

				GameObject newShip = Instantiate(shiptype);
				newShip.transform.position = position;
			}
			shipCount = BossWaveCount;
		}

		Debug.Log("Spawned Ships: " + shipCount);
	}

	public void ReduceShipCount()
	{
		shipCount--;

		Debug.Log("Reduced Ship Count: " + shipCount);

		if (shipCount <= 0)
		{
			NextWave();
		}
	}
}