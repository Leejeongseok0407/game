using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject target = null;
    [SerializeField] float bullitSpeed = 1f;
    [SerializeField] int bullitDmg = 0;
    float hitRange = 0.5f;


    //총알 움직이는 함수
    protected void MoveBullet() {
        Vector3 dir = Vector3.Normalize(target.transform.position - transform.position); 
        transform.Translate(dir * Time.deltaTime * bullitSpeed);
        Debug.Log("moveBullet");
    }

    protected void LookAtBullet()
    {
        Vector3 lookDir = target.transform.position;
        lookDir.z = 0;
        transform.rotation.SetLookRotation(lookDir);
    }

    //불릿이 일정거리 벗어나면 없어지는 함수
    protected void ReturnBullet() 
    {
        // 나와 부모의 사이가 일정거리(1.5f) 도달하면 삭제
        float distance = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distance);
        if (distance < hitRange)
        {
            ObjectPool.ReturnBullet(this);
        }
    }

    public void SetTarget(GameObject setTarget) {
        Debug.Log("setBulletTarget");
        target = setTarget;
    }
    public void SetBulletDmg(int dmg)
    {
        bullitDmg = dmg;
    }
    public int GetBulletDmg() {
        return bullitDmg;
    }

}
