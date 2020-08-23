using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    bool isStageChanged;
    int curStage;
    List<Dictionary<string,object>> curStageMapInfo = null;
    void Awake()
    {
        Instance = this;
        isStageChanged = false;
        curStage = 0;
        SetStageMap(0);
    }
    // Update is called once per frame
    void SetStageMap(int stage)
    {
        curStageMapInfo = CsvReader.Read ("Stage0MapStatusCsv");
        SetMapMatrix();
    }

    void SetMapMatrix()
    {

    }
}
