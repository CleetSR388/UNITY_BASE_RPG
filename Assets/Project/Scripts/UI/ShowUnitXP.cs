using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitExperience : ShowUnitStat
{

    protected override float NewStatValue()
    {
        return unit.GetComponent<UnitStats>().experience;
    }
}
