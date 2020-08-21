﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Attacker
{
    /*
     # gene[4] : int = {0,1,0,0}
    # unitType : int  = 1
    # constitutionNum : int = 3~5*/
    

    void Update()
    {
        TimeGo();
        if (MonsterList.Count > 0)
        {
            TagetSet();
            Attack();
        }
    }

    override protected void SetUnitType() {
        unitType = 1;
    }
}
