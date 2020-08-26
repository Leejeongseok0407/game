using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField]
    int xCorrect = -10;
    [SerializeField]
    int yCorrect = 5;

    float xAnchor = 0.5f;
    float yAnchor = 0.5f;
    List<Dictionary<string,object>> curStageMapStatus = null;
    List<Dictionary<string,object>> curStageWayPoint = null;

    [SerializeField]
    GameObject curStageMap = null;

    [SerializeField]
    GameObject point;
    [SerializeField]
    List<GameObject> wayPointArr;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
    }
    // Update is called once per frame
    public void SetStageMap(int stage)
    {
        switch(stage)
        {
            case 0:
            curStageMapStatus = CsvReader.Read ("Stage0MapStatusCsv");
            curStageWayPoint = CsvReader.Read("Stage0WayPointIndexCsv");
            break;
            default:
            break;
        }
        CreateWayPoint();
    }

    public int GetMapTileStatus(int row, int col)
    {
        return (int)curStageMapStatus[row][Convert.ToString(col)];
    }
    public void CreateWayPoint()
    {
        for(int i = 0; i < curStageWayPoint.Count; i++)
        {
            Vector3 tempPointPosition = GetTilePositionByIndex((int)curStageWayPoint[i]["Row"], (int)curStageWayPoint[i]["Column"]);
            GameObject tempPoint = Instantiate(point, tempPointPosition, Quaternion.identity);
            wayPointArr.Add(tempPoint);
        }
    }
    public Vector3 GetTilePositionByIndex(int row, int col)
    {
        float tilePositionX = curStageMap.transform.position.x + col + xCorrect + xAnchor;
        float tilePositionY = curStageMap.transform.position.y + yCorrect - row + yAnchor;
        return new Vector3(tilePositionX, tilePositionY, 0);
    }

    public void DestroyWayPoint()
    {
        for(int i = 0; i < wayPointArr.Count; i++)
        {
            Destroy(wayPointArr[i]);
        }
        wayPointArr.Clear();
    }

    public List<GameObject> GetWayPoint()
    {
        return wayPointArr;
    } 
}
