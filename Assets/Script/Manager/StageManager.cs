using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    List<Dictionary<string,object>> curStageInfo = null;
    void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        StartStage(0);
    }
    void StartStage(int stage)
    {
        switch(stage)
        {
            case 0:
                curStageInfo = CSVReader.Read ("Stage0Csv");
                break;
            default:
            break;
        }

        for(int i =0; i< curStageInfo.Count; i++)
        {
            MonsterManager.Instance.MakeMonsterWave(stage, (int)curStageInfo[i]["Type"], (int)curStageInfo[i]["Volume"], (int)curStageInfo[i]["Delay"]);
        }
    }
}