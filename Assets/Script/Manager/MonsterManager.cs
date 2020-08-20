using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    List<GameObject> wayPointArr = new List<GameObject>();
    List<Transform> curStageWayPoint;
    void SetWayPoint(int stage)
    {
       // curStageWayPoint = wayPointArr[stage].GetComponent<WayPoint>().GetWayPoint(stage);
    }

    void Start()
    {

    }

    
}
