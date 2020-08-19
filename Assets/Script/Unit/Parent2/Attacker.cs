using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Unit
{
    [Tooltip("파워로 Dmg계산")]
    [SerializeField] protected int power;
    [Tooltip("dd")]
    [SerializeField] protected int constitutionNu;
    [Tooltip("분당 몇회 타격")]
    [SerializeField] protected float attackSpeed;

    [SerializeField] protected GameObject bullet = null;
    //차후에 총알 담을것.
    [SerializeField] protected GameObject bulletContainer = null;
    protected GameObject closeEnemy = null;
    protected List<GameObject> enemyList = new List<GameObject>();
    protected float fTime = 0;
    protected int dmg;
    protected float attackCycle;
    protected GameObject target = null;

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
        GameObject target = enemyList[0];
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

    virtual protected GameObject CallBullet() {
        return Instantiate(bullet, transform.position, Quaternion.identity, transform);
    }

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
