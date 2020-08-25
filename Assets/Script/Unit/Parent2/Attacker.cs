using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Unit
{
    [Tooltip("파워로 Dmg계산")]
    [SerializeField] protected int power = 1;
    /*[Tooltip("dd")]
    [SerializeField] protected int constitutionNu;*/
    [Tooltip("분당 몇회 타격")]
    [SerializeField] protected float attackSpeed = 60;


    protected GameObject closeEnemy = null;
    [SerializeField] protected List<GameObject> MonsterList = new List<GameObject>();
    protected float fTime = 0;
    protected int dmg;
    protected float attackCycle;
    [SerializeField] protected GameObject target = null;

    private void Start()
    {
        AttackCycleInitializer();
        CalculationDmg();
    }
    
    //attackSpeed를 사이클로 변환
    //분당 회 타격으로
    protected void AttackCycleInitializer() {
        attackCycle =  60 / attackSpeed;
    }
    //데미지 계산
    protected void CalculationDmg()
    {
        //차후에 공식으로 교환
        dmg = power;
    }

    protected void TimeGo()
    {
        fTime += Time.deltaTime;
    }

    protected void TagetSet()
    {
        target = MonsterList[0];
    }

    protected void Attack()
    {
        if (target != null && fTime > attackCycle)
        {
            //시간을 초기화함.
            fTime = 0.0f;
            //불릿을 생성
            //차후에 생성에서 켜짐으로 바꿔야함.
            var aBullet = CallBullet();
            //불릿 데미지 설정
            aBullet.GetComponent<Bullet>().SetBulletDmg(dmg);
            aBullet.GetComponent<Bullet>().SetTarget(target);
        }
    }

    protected Bullet CallBullet() {
        return ObjectPool.GetBullet(this.gameObject, unitType);
    }

    //트리거 범위에 몬스터 들어올 경우 몬스터를 리스트에 삽입한다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            MonsterList.Add(collision.gameObject);
        }
    }

    //트리거 범위에서 몬스터 나갈 경우 몬스터를 리스트에서 제거
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject rangeOutEnemy in MonsterList)
        {
            if (rangeOutEnemy == collision.gameObject)
            {
                MonsterList.Remove(rangeOutEnemy);
                Debug.Log("TagetExit");
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
