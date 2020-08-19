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
    private void Awake()
    {
        unitType = 0;
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

    protected override GameObject CallBullet() {

        return Instantiate(bullet, transform.position, Quaternion.identity, transform);
    }
}