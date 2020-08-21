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
        transform.Translate(Vector3.right * Time.deltaTime * bullitSpeed);
        Debug.Log("moveBullet");
    }

    protected void LookAtBullet()
    {
        Vector3 lookDir = target.transform.position- transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    protected void ReturnBullet() 
    {
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
