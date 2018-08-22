using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class LevelSystem : MonoBehaviour
{
    public float XP;
    public int currentLevel;
    UnitStats unitStats;
    GameObject[] playerUnits;
    public float xpnextlevel;

    private void Start()
    {  
        playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        currentLevel = GameObject.FindGameObjectWithTag("PlayerUnit").GetComponent<UnitStats>().currentLevel;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateXp(float xp)
    {
        XP = xp;
        xpnextlevel = 100 * (currentLevel * 3);

        if (XP >= xpnextlevel)
        {
            currentLevel++;

            for (int i = 0; i < playerUnits.Length; i++)
            {
                unitStats = playerUnits[i].GetComponent<UnitStats>();
                unitStats.LevelUp();
                unitStats.experience = 0;
            }

            // add some cool text to show you reached a ew level
        }

        float differencexp = xpnextlevel - XP;

        //  float totaldifference = xpnextlevel - (100 * currentlevel * currentlevel);

        // differencexp / totaldifference
    }
}