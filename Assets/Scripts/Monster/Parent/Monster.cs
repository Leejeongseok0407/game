using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected int mType;
    int hp;
    int velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            int bulletDmg = col.GetComponent<Bullet>().GetDmg();
            ReceiveDmg(bulletDmg);
        }
    }

    void Death()
    {
        Destroy(this);
    }

    void ReceiveDmg(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            Death();
        }
    }

    void TrackWaypoints()
    { }
}
