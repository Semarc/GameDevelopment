using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStartScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(Konstanten.PlayerTag))
		{
			collision.GetComponent<TopDownPlayerController>().currentBattleStarter = this;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(Konstanten.PlayerTag))
		{
			collision.GetComponent<TopDownPlayerController>().currentBattleStarter = null;
		}
	}

	public void StartBattle(Vector2 position)
	{
		Konstanten.previousPlayerPosition = position;
		SceneManager.LoadScene(1);

	}
}