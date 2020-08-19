using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Unit
{
    [SerializeField] protected int power;
    [SerializeField] protected int constitutionNum;
    [Tooltip("분당 몇회 타격")]
    [SerializeField] protected float attackSpeed;

    [SerializeField] protected GameObject bullet = null;
    protected GameObject closeEnemy = null;
    protected List<GameObject> enemyList = new List<GameObject>();
    protected float fTime = 0;
    protected float attackCycle;
    protected GameObject target = null;

    private void Start()
    {
        AttackCycleInitializer();
    }
    
    //attackSpeed를 사이클로 변환
    //분당 회 타격으로
    protected void AttackCycleInitializer() {
        attackCycle =  60 / attackSpeed;
    }

    protected void TimeGo()
    {
        fTime += Time.deltaTime;
    }

    protected void TagetSet()
    {
        GameObject target = enemyList[0];
    }

    interface Attack { }

    //트리거 범위에 몬스터 들어올 경우 몬스터를 리스트에 삽입한다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            enemyList.Add(collision.gameObject);
    }

    //트리거 범위에서 몬스터 나갈 경우 몬스터를 리스트에서 제거
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject rangeOutEnemy in enemyList)
        {
            if (rangeOutEnemy == collision.gameObject)
            {
                enemyList.Remove(rangeOutEnemy);
                break;
            }
        }
    }


    void Buff0(int stat, float time)
    {

    }
    void Buff1(int stat, float time)
    {

    }
    void Buff2(int stat, float time)
    {

    }

}
