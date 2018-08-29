using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    LevelSystem levelSystem;


    public float maxHealth;

    public float maxMana;

    public float maxAttack;

    public float maxMagic;

    public float maxDefense;

    public float maxSpeed;

    public int currentLevel;

    void Start()
    {
        currentLevel = 1;
        maxHealth = health;
        levelSystem = GetComponent<LevelSystem>();

        maxMana = mana;
        levelSystem = GetComponent<LevelSystem>();

        maxAttack = attack;
        levelSystem = GetComponent<LevelSystem>();

        maxMagic = magic;
        levelSystem = GetComponent<LevelSystem>();

        maxDefense = defense;
        levelSystem = GetComponent<LevelSystem>();

        maxSpeed = speed;
        levelSystem = GetComponent<LevelSystem>();
    }

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

	public float ReceiveExperience (float newExperience) {
		experience += newExperience;
        return experience;
	}

    public void LevelUp()
    {
        currentLevel++;
        maxHealth += maxHealth * .025f;
        health = maxHealth;
        
        maxMana += maxMana * .005f;
        mana = maxMana;

        maxAttack += maxAttack * .005f;
        attack = maxAttack;

        maxMagic += maxMagic * .002f;
        magic = maxMagic;

        maxDefense += maxDefense * .002f;
        defense = maxDefense;

        maxSpeed += maxSpeed * .002f;
        speed = maxSpeed;
       
    }

    public void usePotion()
    {

        health += 20;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        GameObject.Find("TurnSystem").GetComponent<TurnSystem>().WaitThenNextTurn();
        //health = GetComponent<UsePotion>().Heal();
    }

}
