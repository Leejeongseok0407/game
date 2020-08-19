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

    void Attack()
    {
        if (target != null && fTime > attackCycle)
        {
            fTime = 0.0f;
            //불릿을 생성함.
            var aBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            //불릿 데미지 설정
            aBullet.GetComponent<BulletWizard>().SetBulletDmg(dmg);
            //방향 벡터 생성
            Vector3 dir = (target.transform.position - transform.position).normalized;
            //앵글을 생성하여 회전각을 생성
            float angle = Vector2.SignedAngle(Vector2.down, dir);
            Quaternion qut = new Quaternion();
            qut.eulerAngles = new Vector3(0, 0, angle);
            aBullet.transform.rotation = qut;
            aBullet.transform.position += dir * 1.0f;
        }
        
    }
}