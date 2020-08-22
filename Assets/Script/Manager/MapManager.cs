using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    bool isStageChanged;
    int curStage;
    const int mapHeightMax = 8;
    const int mapWidthMax = 12;
    int[,] gridStatus = new int[mapHeightMax, mapWidthMax];
    void Awake()
    {
        Instance = this;
        isStageChanged = false;
        curStage = 0;
        SetStage();
    }
    // Update is called once per frame
    void Update()
    {
        if(isStageChanged)
        {
            curStage++;
            SetStage();
        }
        
    }

    void SetStage()
    {
        SetMapMatrix();
    }

    void SetMapMatrix()
    {

    }
}
