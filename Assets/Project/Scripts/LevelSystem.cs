using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelSystem : MonoBehaviour
{
    public int XP;
    public int currentlevel;

    // Update is called once per frame
    void Update()
    {
           
    }

    public void UpdateXp(int xp)
    {
        XP += xp;

        int curlvl = (int)(0.1f * Mathf.Sqrt(XP));

        if (curlvl != currentlevel)
        {
            currentlevel = curlvl;
            // add some cool text to show you reached a new level
        }

        int xpnextlevel = 100 * (currentlevel * 1);
        int differencexp = xpnextlevel - XP;

        int totaldifference = xpnextlevel - (100 * currentlevel * currentlevel);

        // differencexp / totaldifference
    }
}