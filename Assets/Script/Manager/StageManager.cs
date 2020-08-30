using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    int curStage;

    int maxStage = 2;
    int nexusHp;

    [SerializeField]
    GameObject nextStageBtn = null;

    [SerializeField]
    GameObject endDemoBtn = null;
    [SerializeField]
    GameObject defeatBtn = null;
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
        if(curStage == maxStage)
        {
            endDemoBtn.SetActive(true);
        }
        else
        {
            nextStageBtn.SetActive(true);
            SlotInventory.Instance.InventoryReset();
        }
    }

    public void GoToNextStage()
    {
        
            nextStageBtn.SetActive(false);
            curStage++;
            StartStage();
    }
    public void Defeat()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Defeat");
        curStage = 0;
    }

    public void ReceiveDmgNexus()
    {
        nexusHp--;
        if(nexusHp == 0)
        {
            defeatBtn.SetActive(true); 
            Time.timeScale = 0;
        }
    }
}