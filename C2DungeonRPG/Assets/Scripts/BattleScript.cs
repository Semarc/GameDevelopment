using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using TMPro;

using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour
{
	#region UIElements

	[SerializeField] Button AttackButton;
	[SerializeField] Button DefendButton;
	[SerializeField] Button HealButton;
	[SerializeField] Button RunButton;
	[SerializeField] TMP_Text HPText;
	[SerializeField] TMP_Text InfoText;

	#endregion


	#region BattleVariables


	private int PlayerHP { get => playerHP; set { playerHP = Math.Max(value, 0); } }
	private const int PlayerMaxHP = 10;
	private int EnemyHP = 20;
	private bool EnemyCharging;
	private bool PlayerDefending;
	private int playerHP;


	#endregion

	void Start()
	{
		AttackButton.onClick.AddListener(Attack);
		DefendButton.onClick.AddListener(Defend);
		HealButton.onClick.AddListener(Heal);
		RunButton.onClick.AddListener(Run);

		PlayerHP = PlayerMaxHP;
		InfoText.gameObject.SetActive(false);
		UpdatePlayerHP();
	}

	#region EventCallBacks

	private void Attack()
	{
		int Damage = Random.Range(1, 3);
		EnemyHP -= Damage;

		if (EnemyHP <= 0)
		{
			ShowInfoText($"Player attacks and deals {Damage} damage. The Enemy is dead");
			BattleFinished($"Player attacks and deals {Damage} damage. The Enemy is dead");
		}
		else
		{
			ShowInfoText($"Player attacks and deals {Damage} damage");
			EnemyTurn();
		}
	}

	private void Defend()
	{
		PlayerDefending = true;
		ShowInfoText("Player Is Defending");
		EnemyTurn();
	}

	private void Heal()
	{
		int heal = Math.Max(PlayerHP + Random.Range(2, 5), PlayerMaxHP) - PlayerHP;
		PlayerHP += heal;
		UpdatePlayerHP();
		ShowInfoText($"Player was healed by {heal} HP");
		EnemyTurn();
	}

	private void Run()
	{
		ShowInfoText($"The player runs from the battle");
		BattleFinished($"The player runs from the battle");
	}

	#endregion


	private void EnemyTurn()
	{
		string DisplayText;
		AttackButton.interactable =
		DefendButton.interactable =
		HealButton.interactable =
		RunButton.interactable = false;

		if (EnemyCharging)
		{
			if (PlayerDefending)
			{
				DisplayText = "You block the enemie's deadly attack";
			}
			else
			{
				DisplayText = "The enemy unleashes a deadly attack. You are dead";
				playerHP = 0;
				BattleFinished(DisplayText);
			}
		}
		else
		{
			int EnemyAction = Random.Range(0, 4);

			if (EnemyAction == 0)
			{
				EnemyCharging = true;
				DisplayText = "Enemy is Charging a deadly Attack";
			}
			else
			{
				int damage = Random.Range(2,5);
				if (PlayerDefending)
				{
					DisplayText = $"The player block {damage} HP of damage";
				}
				else
				{
					PlayerHP -= damage;
					DisplayText = PlayerHP <= 0 ? $"The enemy deals {damage} HP of damage. You are dead" : $"The enemy deals {damage} HP of damage";
				}
			}
		}
		PlayerDefending = false;
		StartCoroutine(EnemyTurnCo(DisplayText));
	}

	private IEnumerator EnemyTurnCo(string DisplayText)
	{
		yield return new WaitForSeconds(2.5f);
		AttackButton.interactable =
		DefendButton.interactable =
		HealButton.interactable =
		RunButton.interactable = true;
		ShowInfoText(DisplayText);
		UpdatePlayerHP();
	}


	private void BattleFinished(string DisplayText)
	{

	}

	private void UpdatePlayerHP()
	{
		HPText.text = $"{PlayerHP} HP";
	}

	private void ShowInfoText(string Info)
	{
		InfoText.gameObject.SetActive(true);
		InfoText.text = Info;
		StartCoroutine(HideInfoText());
	}

	IEnumerator HideInfoText()
	{
		yield return new WaitForSeconds(2);
		InfoText.gameObject.SetActive(false);
	}
}