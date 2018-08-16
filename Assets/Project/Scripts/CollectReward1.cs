using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectReward : MonoBehaviour {

	[SerializeField]
	private float experience;
    public class CollectReward : MonoBehaviour
    {
        public bool enemyDefeated;

        // Use this for initialization
        void Start() {
            GameObject turnSystem = GameObject.Find("TurnSystem");
            turnSystem.GetComponent<TurnSystem>().enemyEncounter = gameObject;
            enemyDefeated = false;
        }

        public void GetReward() {
            GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
            float experiencePerUnit = experience / livingPlayerUnits.Length;
            enemyDefeated = true;


            foreach (GameObject playerUnit in livingPlayerUnits) {
                playerUnit.GetComponent<UnitStats>().ReceiveExperience(experiencePerUnit);
            }

            Destroy(gameObject);
            public bool IsEnemyDefeated()
            {
                return enemyDefeated;
            }
        }
    }
}
