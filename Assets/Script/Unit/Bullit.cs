using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullit : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition = Vector3.zero;
    [SerializeField] GameObject ExplosionParticle = null;
    [SerializeField] float bullitSpeed;
    [SerializeField] int bullitDmg;
    [SerializeField] float bullitRange;

    //불릿이 일정거리 벗어나면 없어지는 함수
    void AttackBullit() 
    {
        //불릿 이동함수
        transform.Translate(targetPosition * Time.deltaTime * bullitSpeed);

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
    public int GetBullitDmg() {
        return bullitDmg;
    }

}
