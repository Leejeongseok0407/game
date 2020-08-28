using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWizard : Bullet
{
    [SerializeField] float ExplosionRange = 5.0f;
    [SerializeField] int ExplosionDmg;
    [SerializeField] GameObject ExplosionImg;
    [SerializeField] GameObject defaultImg;
    [SerializeField] Vector3 ExplosionPosition;
    private void Awake()
    {
        ExplosionImg.SetActive(false);
        bulletType = 1;
        defaultImg.SetActive(true);
    }
    private void Update()
    {
        MoveBullet();
        LookAtBullet();
        CalculateDistance();
        if (distance < hitRange  + 0.2f)
        {
            ExplosionImg.SetActive(true);
            defaultImg.SetActive(false);
        }
        if (distance < hitRange)
        {
            ExplosionDmg = bullitDmg / 2;
            Explosion();
            ReturnBullet();
            HitMonster();
            ExplosionImg.SetActive(false);
        }
    }


    void Explosion()
    {

        // 폭발 반경에 있는 몹 전부 찾음
        Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, ExplosionRange);
        for (int i = 0; i < hitsCol.Length; i++)
            if (hitsCol[i].gameObject.tag == "Monster")
                Debug.Log(hitsCol[i].name + "--");

        
        ExplosionPosition = transform.position;

       // StartCoroutine(ExplosionIEnum());
        // 몬스터 전부에게 데미지
        foreach (Collider2D hit in hitsCol)
        {
            if (hit.gameObject.tag == "Monster")
            {
                Debug.Log(hit.gameObject.name + "딜함");
                hit.GetComponent<Monster>().ReceiveDmg(ExplosionDmg);
            }
        }
        //ExplosionParticle생성.
        //차후에 바꾸자
    }

    public void ExplosionF() {
        Debug.Log("++");
    }


    IEnumerable ExplosionIEnum()
    {
        Debug.Log("++");

        var Explosion = Instantiate(ExplosionImg, this.transform.localPosition, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        Destroy(Explosion);

    }
}

