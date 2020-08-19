using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition = Vector3.zero;
    [SerializeField] float bullitSpeed;
    [SerializeField] int bullitDmg = 0;
    //나중에 이건 맵 크기에서 최대로 갈 경우나 아님 맵 밖으로 나가면 제거되게 해야함.
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
    public void SetBulletDmg(int dmg)
    {
        bullitDmg = dmg;
    }
    public int GetBulletDmg() {
        return bullitDmg;
    }

}
