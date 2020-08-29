using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected GameObject target = null;
    [SerializeField] float bullitSpeed = 1f;
    [SerializeField] protected int bullitDmg = 1;
    protected int bulletType;
    protected float hitRange = 0.5f;
    protected float distance;


    //총알 움직이는 함수
    protected void MoveBullet() {
        if (target.activeSelf == true)
            transform.Translate(Vector3.right * Time.deltaTime * bullitSpeed);
        else
            ReturnBullet();
    }

    protected void LookAtBullet()
    {
        Vector3 lookDir = target.transform.position- transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    protected void CalculateDistance() {

        distance = Vector3.Distance(transform.position, target.transform.position);
    }

    protected void ReturnBullet() 
    {
        ObjectPool.ReturnBullet(this, bulletType);
    }

    public void SetTarget(GameObject setTarget) {
        target = setTarget;
    }
    public void SetBulletDmg(int dmg)
    {
        bullitDmg = dmg;
    }
    protected void HitMonster()
    {   
        if(target.activeSelf == true)
        {
            target.GetComponent<Monster>().ReceiveDmg(bullitDmg);
        }
    }
}
