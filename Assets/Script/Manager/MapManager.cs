using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField]
    float xCorrect = -10;
    [SerializeField]
    float yCorrect = 5;

    const int mapHeight = 6;
    const int mapWidth = 10;
    float xAnchor = 0.5f;
    float yAnchor = 0.5f;

    int[,] mapMatrix;
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
        mapMatrix  = new int[mapHeight, mapWidth];
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
            curStageMapStatus = CsvReader.Read ("Stage" + 0 + "MapStatusCsv");
            curStageWayPoint = CsvReader.Read("Stage0WayPointIndexCsv");
            break;
            default:
            break;
        }
        CreateMapStatusMatrix();
        CreateWayPoint();
    }

    public int GetMapTileStatus(int row, int col)
    {
        return mapMatrix[row, col];
    }
    public void CreateWayPoint()
    {
        for(int i = 0; i < curStageWayPoint.Count; i++)
        {
            Vector3 tempPointPosition = GetTilePositionByIndex((int)curStageWayPoint[i]["Row"], (int)curStageWayPoint[i]["Column"]);
            tempPointPosition.y -= 0.5f;
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
    public int GetTileRowByPosition(Transform pos)
    {
        return Mathf.RoundToInt(curStageMap.transform.position.y + yCorrect + yAnchor - pos.position.y); 
    }
    public int GetTileColumnByPosition(Transform pos)
    {
        return Mathf.RoundToInt(pos.position.x -curStageMap.transform.position.x - xCorrect - xAnchor); 
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

    public void CreateMapStatusMatrix()
    {
        for(int i = 0; i < mapHeight; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                mapMatrix[i, j] = (int)curStageMapStatus[i][Convert.ToString(j)];
            }
        }
    }
    
    public void SetMapMatrixStatusByIndex(int row, int col, int change)
    {
        mapMatrix[row, col] += change;
    }
}
