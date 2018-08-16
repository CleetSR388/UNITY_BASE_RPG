using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class UnitStats : MonoBehaviour, IComparable {
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject damageTextPrefab;

	[SerializeField]
	private Vector2 damageTextPosition;

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;
	public float experience;

	public int nextActTurn;

	private bool dead = false;

	public void CalculateNextActTurn (int currentTurn) {
		nextActTurn = currentTurn + Mathf.CeilToInt (100f / speed);
	}

	public bool IsDead () {
		return dead;
	}

	public int CompareTo (object otherStats) {
		return nextActTurn.CompareTo (((UnitStats)otherStats).nextActTurn);
	}

	public void ReceiveDamage (float damage) {
		health -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (damageTextPrefab, HUDCanvas.transform);
		damageText.GetComponent<Text> ().text = "" + Mathf.FloorToInt (damage);
		damageText.transform.localPosition = damageTextPosition;
		damageText.transform.localScale = Vector2.one;
		Destroy (damageText.gameObject, 1f);

		if (health <= 0) {
			dead = true;
			gameObject.tag = "DeadUnit";
			Destroy (gameObject);
		}

		GameObject.Find ("TurnSystem").GetComponent<TurnSystem> ().WaitThenNextTurn ();
	}

	public void ReceiveExperience (float newExperience) {
		experience += newExperience;
	}
}
