using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    int mapMaxHeight;
    int mapMaxWidth;
    List<Dictionary<string,object>> curStageMapStatus = null;
    List<Dictionary<string,object>> curStageWayPoint = null;

    [SerializeField]
    GameObject curStageMap = null;

    [SerializeField]
    GameObject point;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Debug.Log(GetTilePositionByIndex(0,0));
        Debug.Log(GetTilePositionByIndex(5,10));
    }
    // Update is called once per frame
    public void SetStageMap(int stage)
    {
        switch(stage)
        {
            case 0:
            curStageMapStatus = CsvReader.Read ("Stage0MapStatusCsv");
            curStageWayPoint = CsvReader.Read("Stage0WayPointIndex");
            break;
            default:
            break;
        }
    }

    public Vector3 GetTilePositionByIndex(int row, int col)
    {
        float tilePositionX = curStageMap.transform.position.x + 5 - row;
        float tilePositionY = curStageMap.transform.position.y + col - 10;
        return new Vector3(tilePositionX, tilePositionY, 0);
    }
}
