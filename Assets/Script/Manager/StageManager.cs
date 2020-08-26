using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    int curStage;
    void Awake()
    {
        Instance = this;
        curStage = 0;
    }
    void Start()
    {
        StartStage();
    }
    void StartStage()
    {
        SetStageInfo();
        StartCoroutine(MonsterManager.Instance.StartMonsterWave(curStage));
    }
    void SetStageInfo()
    {
        MapManager.Instance.SetStageMap(curStage);
        MonsterManager.Instance.SetStageWaveInfo(curStage);
    }

    public void EndStage()
    {
        curStage++;
        //StartStage();
    }
}