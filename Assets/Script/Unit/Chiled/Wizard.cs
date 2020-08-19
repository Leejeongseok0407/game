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

    void Attack()
    {
        if (target != null && fTime > attackCycle)
        {
            //시간을 초기화함.
            fTime = 0.0f;
            //불릿을 생성
            //차후에 생성에서 켜짐으로 바꿔야함.
            var aBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            //불릿 데미지 설정
            aBullet.GetComponent<BulletWizard>().SetBulletDmg(dmg);
            //방향 벡터 생성
            aBullet.GetComponent<BulletWizard>().SetTargetPosition((target.transform.position - transform.position).normalized);
            //위치 지정
            aBullet.transform.localScale = new Vector3(0.5f, 0.5f);
        }
    }
}
