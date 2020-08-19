using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition = Vector3.zero;
    [SerializeField] protected GameObject ExplosionParticle = null;
    [SerializeField] float bullitSpeed;
    [SerializeField] int bullitDmg;
    [SerializeField] float bullitRange;

    
    //총알 움직이는 함수
    protected void MoveBullit() {
        transform.Translate(targetPosition * Time.deltaTime * bullitSpeed);
    }

    //불릿이 일정거리 벗어나면 없어지는 함수
    protected void RemoveBullit() 
    {
        // 나와 부모의 사이가 일정거리(1.5f) 도달하면 삭제
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > bullitRange)
        {
            Destroy(gameObject);
        }
    }
    public void SetTargetPosition(Vector3 Target) {
        targetPosition = Target;
    }
    public int GetBulletDmg() {
        return bullitDmg;
    }

}
