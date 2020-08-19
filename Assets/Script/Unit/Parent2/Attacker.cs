using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : Unit
{
    [SerializeField] protected int power;
    [SerializeField] protected int constitutionNum;
    [Tooltip("분당 몇회 타격")]
    [SerializeField] protected float attackSpeed;

    [SerializeField] GameObject bullet = null;
    private GameObject closeEnemy = null;
    private List<GameObject> enemyList = new List<GameObject>();
    private float fTime = 0;
    private float attackCycle;

    private void Start()
    {
        attackCycle = attackSpeed / 60;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void TimeGo()
    {
        fTime += Time.deltaTime;
        if (enemyList.Count > 0)
        {
            TagetOn();
        }
    }
    void TagetOn()
    {
        GameObject target = enemyList[0];
        Attack();
        if (gameObject.tag == "Wizard")
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

        else if (gameObject.tag == "Ranger")
        {
            if (target != null && fTime > attackCycle)
            {
                fTime = 0.0f;
                //불릿을 생성함.
                var aBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
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

    void Attack()
    {

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
