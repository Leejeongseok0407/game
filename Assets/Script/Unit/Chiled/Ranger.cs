using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : Attacker
{
    /*
    gene[4] += {1,0,0,0}
    unitType  = 0
    constitutionNum = 0~2
    */

    void Update()
    {
        TimeGo();
        if (MonsterList.Count > 0)
        {
            TagetSet();
            Attack();
        }
    }
    override protected void SetUnitType()
    {
        unitType = 1;
    }
}