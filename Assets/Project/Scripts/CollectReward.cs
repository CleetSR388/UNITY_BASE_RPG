using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectReward : MonoBehaviour
{

    [SerializeField]
    private float experience;
    LevelSystem levelSystem;
    private float newExperience;
    // Use this for initialization
    void Start()
    {
        levelSystem = GameObject.Find("PlayerParty").GetComponent<LevelSystem>();
        GameObject turnSystem = GameObject.Find("TurnSystem");
        turnSystem.GetComponent<TurnSystem>().enemyEncounter = gameObject;
    }

    public void GetReward()
    {
        GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        float experiencePerUnit = experience / livingPlayerUnits.Length;
        foreach (GameObject playerUnit in livingPlayerUnits)
        {
            newExperience = playerUnit.GetComponent<UnitStats>().ReceiveExperience(experiencePerUnit);
            levelSystem.UpdateXp(newExperience);
        }
        Destroy(gameObject);
    }
}