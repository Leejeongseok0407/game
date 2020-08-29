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
            GameObject tempPoint = Instantiate(point, tempPointPosition, Quaternion.identity);
            wayPointArr.Add(tempPoint);
        }
    }

     public bool IsEmpty(Vector3 pos)  //위치 을 넣으면 타일의 상태를 검사해 유닛을 놓을수있으면 놓을수 없는 상태로 변경한 후 true 반환 
    {  
        if(mapMatrix[Mathf.RoundToInt(curStageMap.transform.position.y + yCorrect + yAnchor - pos.y), Mathf.RoundToInt(pos.x -curStageMap.transform.position.x - xCorrect - xAnchor)] == 1)
        {
            mapMatrix[Mathf.RoundToInt(curStageMap.transform.position.y + yCorrect + yAnchor - pos.y), Mathf.RoundToInt(pos.x -curStageMap.transform.position.x - xCorrect - xAnchor)]++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 GetTilePositionByIndex(int row, int col) //행과 열을 넣으면 타일의 좌표를 반환
    {
        float tilePositionX = curStageMap.transform.position.x + col + xCorrect + xAnchor;
        float tilePositionY = curStageMap.transform.position.y + yCorrect - row + yAnchor;
        return new Vector3(tilePositionX, tilePositionY, 0);
    }
    
    public Vector3 GetTilePositionByPosition(Vector3 Pos) //행과 열을 넣으면 타일의 좌표를 반환
    {
        float tilePositionX = curStageMap.transform.position.x + (int)(Pos.x - curStageMap.transform.position.x)  + xCorrect + xAnchor;
        float tilePositionY = curStageMap.transform.position.x + (int)(Pos.y - curStageMap.transform.position.y) + yCorrect + yAnchor;
        return new Vector3(tilePositionX, tilePositionY, Pos.z);
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
}
