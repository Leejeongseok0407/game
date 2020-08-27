using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected int type;
    int hp;
    int armor;
    float velocity;
    float offset;

    bool isAlive;
    List<GameObject> curStageWayPoint;
    int nextWayPointIndex;
    void Update()
    {
        TrackWayPoint();
    }

    void TrackWayPoint()
    {
        
        offset += velocity * Time.deltaTime;
        transform.position = Vector3.Lerp(curStageWayPoint[nextWayPointIndex-1].transform.position, curStageWayPoint[nextWayPointIndex].transform.position, offset/Vector3.Distance(curStageWayPoint[nextWayPointIndex-1].transform.position, curStageWayPoint[nextWayPointIndex].transform.position));
        CheckArrive();
    }

    void CheckArrive()
    {
        if(Vector3.Distance(transform.position, curStageWayPoint[nextWayPointIndex].transform.position) == 0)
        {
            offset = 0;
            nextWayPointIndex++;
            Debug.Log("Reach");
            if(nextWayPointIndex == curStageWayPoint.Count)
            {
                StageManager.Instance.ReceiveDmgNexus();
                Death();
            }
        }
    }
    public void SetMonster(int type, int hp, int armor, List<GameObject> curStageWayPoint)
    {
        switch(type)
        {
            case 0:
            velocity = 2f;
            break;
            case 1:
            velocity = 1.5f;
            break;
            case 2:
            velocity = 1f;
            break;
            case 3:
            velocity = 1f;
            break;
            default:
            break;
        }
        this.type = type;
        this.hp = hp;
        this.armor = armor;
        this.curStageWayPoint = curStageWayPoint;
        this.nextWayPointIndex = 1;
        this.isAlive = true;

        //this.preCalculatedVectorToNextWayPoint = CalculateVectorToNextWayPoint(curStageWayPoint[0].position);
        Debug.Log("Monster Type" + this.type + "Allocated");
    }

    Vector3 CalculateVectorToNextWayPoint(Vector3 curPosition)
    {
        return curStageWayPoint[nextWayPointIndex].transform.position-curPosition;
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
        this.isAlive = false;
        MonsterManager.Instance.FreeMonster(this);
    }    
}
