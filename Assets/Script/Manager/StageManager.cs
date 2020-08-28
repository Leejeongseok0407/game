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
        CameraManager.Instance.MoveCameraToStage(curStage); //카메라이동
        MapManager.Instance.SetStageMap(curStage);  //맵 설정, 웨이포인트 생성 
        MonsterManager.Instance.SetStageWaveInfo(curStage); // 웨이브, 몹 정보
    }

    public void EndStage()
    {
        MapManager.Instance.DestroyWayPoint();
        //버튼.setActive(true); 

        //SlotInventory.Instance.InventoryReset();
        
    }

    public void GoToNextStage()
    {
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