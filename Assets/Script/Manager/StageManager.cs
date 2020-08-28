using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    int curStage;
    int nexusHp;
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
        nexusHp = 5;
        CameraManager.Instance.MoveCameraToStage(curStage);
        MapManager.Instance.SetStageMap(curStage);
        MonsterManager.Instance.SetStageWaveInfo(curStage);
    }

    public void EndStage()
    {
        MapManager.Instance.DestroyWayPoint();
        curStage++;
        StartStage();
    }

    public void GoToStartScreen()
    {
        Debug.Log("Defeat");
    }

    public void Defeat()
    {
        GoToStartScreen();
        curStage = 0;
    }

    public void ReceiveDmgNexus()
    {
        nexusHp--;
        if(nexusHp == 0)
        {
            Defeat();
        }
    }
}