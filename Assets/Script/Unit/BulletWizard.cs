using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWizard : Bullet
{
    [SerializeField] float ExplosionRange;
    private void Update()
    {
        MoveBullit();
        RemoveBullit();
    }
    void Explosion()
    {
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 1.5f)
        {
            // 총알에서 1.0f 반경에 있는 애들을 전부 찾음
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

            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
