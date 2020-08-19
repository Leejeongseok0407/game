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

    void Attack()
    {

        if (target != null && fTime > attackCycle)
        {
            fTime = 0.0f;
            //불릿을 생성
            var aBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            aBullet.GetComponent<BullitWizard>().SetTargetPosition((target.transform.position - transform.position).normalized);
            aBullet.transform.localScale = new Vector3(0.5f, 0.5f);
        }
    }
}
