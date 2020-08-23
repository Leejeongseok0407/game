using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    int mapMaxHeight;
    int mapMaxWidth;
    List<Dictionary<string,object>> curStageMapInfo = null;
    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    public void SetStageMap(int stage)
    {
        switch(stage)
        {
            case 0:
            curStageMapInfo = CsvReader.Read ("Stage0MapStatusCsv");
            break;
            default:
            break;
        }
    }
}
