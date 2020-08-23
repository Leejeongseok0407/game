using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected int type;
    int hp;
    int armor;
    int velocity;

    Vector3 preCalculatedVectorToNextWayPoint;
    Vector3 curVectorToNextWayPoint;
    List<Transform> curStageWayPoint;
    int nextWayPointIndex;
    void Update()
    {
        TrackWayPoint();
    }

    void TrackWayPoint()
    {
        curVectorToNextWayPoint = CalculateVectorToNextWayPoint(transform.position);
        CheckArrive();
        transform.Translate(curVectorToNextWayPoint.normalized * velocity * Time.deltaTime);
    }

    void CheckArrive()
    {
        if(Vector3.Dot(preCalculatedVectorToNextWayPoint, curVectorToNextWayPoint) <= 0)
        {
            nextWayPointIndex++;
            preCalculatedVectorToNextWayPoint = CalculateVectorToNextWayPoint(transform.position);
        }
        if(curStageWayPoint.Count == nextWayPointIndex-1)
        {
            Death();
        }
    }
    public void SetMonster(int type, int hp, int armor, List<Transform> curStageWayPoint)
    {
        this.type = type;
        this.hp = hp;
        this.armor = armor;
        this.curStageWayPoint = curStageWayPoint;
        this.nextWayPointIndex = 1;

        this.preCalculatedVectorToNextWayPoint = CalculateVectorToNextWayPoint(curStageWayPoint[0].position);
    }

    Vector3 CalculateVectorToNextWayPoint(Vector3 curPosition)
    {
        return curStageWayPoint[nextWayPointIndex].position-curPosition;
    }
    public void ReceiveDmg(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            Death();
        }
    }
    public int GetMonsterType()
    {
        return type;
    }
    void Death()
    {
        MonsterManager.Instance.FreeMonster(this);
    }    
}
