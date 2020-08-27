using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField]
    float xCorrect = 0;
    [SerializeField]
    float yCorrect = 7;

    const int mapHeight = 6;
    const int mapWidth = 10;
    float xAnchor = 0.5f;
    float yAnchor = 0.5f;

    int[,] mapMatrix;
    List<Dictionary<string,object>> curStageMapStatus = null;
    List<Dictionary<string,object>> curStageWayPoint = null;

    [SerializeField]
    List<GameObject> stageMapList = null;
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
        Debug.Log("Current Stage = " + stage);
        curStageMap = stageMapList[stage];
        curStageMapStatus = CsvReader.Read ("Stage" + stage + "MapStatusCsv");
        curStageWayPoint = CsvReader.Read("Stage" + stage + "WayPointIndexCsv");
        
        CreateMapStatusMatrix();
        CreateWayPoint();
    }
    public void CreateWayPoint()
    {
        for(int i = 0; i < curStageWayPoint.Count; i++)
        {
            Vector3 tempPointPosition = GetTilePositionByIndex((int)curStageWayPoint[i]["Row"], (int)curStageWayPoint[i]["Column"]);
            tempPointPosition.y -= 0.5f;
            Debug.Log(curStageMap.transform.position);
            Debug.Log(tempPointPosition);
            Debug.Log("WayPoint " + i + "Created");
            GameObject tempPoint = Instantiate(point, tempPointPosition, Quaternion.identity);
            wayPointArr.Add(tempPoint);
        }
    }

    public int GetTileRowByPosition(Transform pos)  //위치를 넣으면 타일의 행 반환
    {
        return Mathf.RoundToInt(curStageMap.transform.position.y + yCorrect + yAnchor - pos.position.y); 
    }
    public int GetTileColumnByPosition(Transform pos)   //위치를 넣으면 타일의 열 반환 
    {
        return Mathf.RoundToInt(pos.position.x -curStageMap.transform.position.x - xCorrect - xAnchor); 
    }
     public int GetMapTileStatus(int row, int col)  //행과 열을 넣으면 타일의 상태를 반환
    {
        return mapMatrix[row, col];
    }

    public Vector3 GetTilePositionByIndex(int row, int col) //행과 열을 넣으면 타일의 좌표를 반환
    {
        float tilePositionX = curStageMap.transform.position.x + col + xCorrect + xAnchor;
        float tilePositionY = curStageMap.transform.position.y + yCorrect - row + yAnchor;
        return new Vector3(tilePositionX, tilePositionY, 0);
    }

    public void SetMapMatrixStatusByIndex(int row, int col, int change) //행,열에 해당하는 타일의 상태를 change만큼 변경함(유닛을 놓는다면 1을 더해서 1에서 2로 유닛을 제거했다면 -1을 더해서 2에서 1로)
    {
        mapMatrix[row, col] += change;
    }
    
    public void DestroyWayPoint()
    {
        for(int i = 0; i < wayPointArr.Count; i++)
        {
            Destroy(wayPointArr[i]);
            Debug.Log("Waypoint" + i + "Destroy");
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
}
