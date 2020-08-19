using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Attacker
{
    /*
     # gene[4] : int = {0,1,0,0}
    # unitType : int  = 1
    # constitutionNum : int = 3~5*/
    private void Awake()
    {
        unitType = 1;
        SetRange();
    }

    void Update()
    {
        TimeGo();
        if (enemyList.Count > 0)
        {
            TagetSet();
            Attack();
        }
    }
    protected override GameObject CallBullet()
    {
        return Instantiate(bullet, transform.position, Quaternion.identity, transform);
    }
}
