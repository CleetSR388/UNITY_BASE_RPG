using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSystem : MonoBehaviour
{


    public int XP;
    public int currentlevel;

    // put the CollectReward script in the respective field in the Unity editor
    public CollectReward rewardObj;

    void Update()
    {
        if (rewardObj.IsEnemyDefeated())
        {
            UpdateXp(5);
        }
    }


    public void UpdateXp(int xp)
    {
         XP += xp;
        }

        int curlvl = (int)(0.1f * Mathf.Sqrt(XP));

        if (curlvl != currentlevel)
        {
            currentlevel = curlvl;
            // add some cool text to show you reached a ew level
        }

        int xpnextlevel = 100 * (currentlevel * 1);
        int differencexp = xpnextlevel - XP;

        int totaldifference = xpnextlevel - (100 * currentlevel * currentlevel);

        // differencexp / totaldifference
    }
}