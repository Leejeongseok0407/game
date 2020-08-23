using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    

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
        SetStageInfo(stage);
        StartCoroutine(MonsterManager.Instance.StartMonsterWave(stage));
    }
    void SetStageInfo(int stage)
    {
        MonsterManager.Instance.SetStageWaveInfo(0);
    }

    
}