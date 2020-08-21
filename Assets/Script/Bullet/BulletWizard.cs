using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWizard : Bullet
{
    [SerializeField] float ExplosionRange = 2.0f;
    [SerializeField] GameObject ExplosionParticle = null;
    private void Awake()
    {
        bulletType = 1;
    }
    private void Update()
    {
        MoveBullet();
        LookAtBullet();
        CalculateDistance();
        if (distance < hitRange)
        {
            Explosion();
            ReturnBullet();
        }
    }

    void Explosion()
    {
        
            // 폭발 반경에 있는 몹 전부 찾음
            Collider2D[] hitsCol = Physics2D.OverlapCircleAll(transform.position, ExplosionRange);
            // 몬스터 전부에게 데미지
            foreach (Collider2D hit in hitsCol)
            {
                if (hit.gameObject.tag == "Enemy")
                {
                    //hit.gameObject.GetComponent<Mob1>().damage(1);
                    //몬스터 데미지 입는거 적용
                }
            }
        //ExplosionParticle생성.
        if (ExplosionParticle != null)
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);

        
    }
}
