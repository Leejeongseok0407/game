using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    float stageStartTime;
    int allocatedMonsterNum;
    int monsterNumNeedToCreate;
    int createdMonsterNum;
    Vector3 enqueuedMonsterPos = new Vector3(100, 100, 100);
    List<Dictionary<string,object>> mobInfo = null;
    List<Dictionary<string,object>> curStageWaveInfo = null;

    [SerializeField]
    private GameObject lightMonster = null;
    [SerializeField]
    private GameObject mediumMonster = null;
    [SerializeField]
    private GameObject heavyMonster = null;
    [SerializeField]
    private GameObject armoredMonster = null;

    private int lightMonsterMaxSize = 100;
    private int mediumMonsterMaxSize = 60;
    private int heavyMonsterMaxSize = 30;
    private int armoredMonsterMaxSize = 30;
    
    Queue<Monster> lightMonsterQueue = new Queue<Monster>();
    Queue<Monster> mediumMonsterQueue = new Queue<Monster>();
    Queue<Monster> heavyMonsterQueue = new Queue<Monster>();
    Queue<Monster> armoredMonsterQueue = new Queue<Monster>();

    void Awake()
    {
        Instance = this;
        Initialize();

        mobInfo = CsvReader.Read ("MobInfoCsv");
    }
    private void CheckStageEnd()
    {
        if(allocatedMonsterNum == 0 && (monsterNumNeedToCreate == createdMonsterNum))
        {
            Debug.Log("Stage End");
            StageManager.Instance.EndStage();
        }
    }
    private void Initialize()
    {
        for (int i = 0; i < lightMonsterMaxSize; i++)
        {
            if (lightMonster != null)
                lightMonsterQueue.Enqueue(FirstCreateNewMonster(0));
        }

        for (int i = 0; i < mediumMonsterMaxSize; i++)
        {
            if (mediumMonster != null)
                mediumMonsterQueue.Enqueue(FirstCreateNewMonster(1));
        }

        for (int i = 0; i < heavyMonsterMaxSize; i++)
        {
            if (heavyMonster != null)
                heavyMonsterQueue.Enqueue(FirstCreateNewMonster(2));
        }

        for (int i = 0; i < armoredMonsterMaxSize; i++)
        {
            if (armoredMonster != null)
                armoredMonsterQueue.Enqueue(FirstCreateNewMonster(3));
        }
        Debug.Log("Init Complete");
    }

    private Monster FirstCreateNewMonster(int type)
    {
        Monster newMonster = null;
        switch(type)
        {
            case 0:
                newMonster = Instantiate(lightMonster).GetComponent<Light>();
                break;
            case 1:
                newMonster = Instantiate(mediumMonster).GetComponent<Medium>();
                break;
            case 2:
                newMonster = Instantiate(heavyMonster).GetComponent<Heavy>();

                break;
            case 3:
                newMonster = Instantiate(armoredMonster).GetComponent<Armored>();
                break;
            default:
                Debug.Log("not valid type");
                return null;
        }

        newMonster.gameObject.SetActive(false);
        newMonster.transform.position = enqueuedMonsterPos;
        return newMonster;
    }
    
    public void AllocateMonster(int type, int hp, int armor)
    {
        Monster calledMonster = null;
        switch(type)
        {
            case 0:
                calledMonster = Instance.lightMonsterQueue.Dequeue();         
                break;
            case 1:
                calledMonster = Instance.mediumMonsterQueue.Dequeue();
                break;
            case 2:
                calledMonster = Instance.heavyMonsterQueue.Dequeue();
                break;
            case 3:
                calledMonster = Instance.armoredMonsterQueue.Dequeue();
                break;
            default:
                Debug.Log("not valid type");
                break;
        }
        calledMonster.SetMonster(type, hp, armor, MapManager.Instance.GetWayPoint());
        calledMonster.gameObject.SetActive(true);
        calledMonster.transform.position = MapManager.Instance.GetWayPoint()[0].transform.position;
        allocatedMonsterNum++;
        createdMonsterNum++;
    }

    public void FreeMonster(Monster allocatedMonster)
    {
        int type = allocatedMonster.GetMonsterType();
        allocatedMonster.gameObject.SetActive(false);
        allocatedMonster.transform.position = enqueuedMonsterPos;

        switch(type)
        {
            case 0:
            Instance.lightMonsterQueue.Enqueue(allocatedMonster);
            break;
            case 1:
            Instance.mediumMonsterQueue.Enqueue(allocatedMonster);
            break;
            case 2:
            Instance.heavyMonsterQueue.Enqueue(allocatedMonster);
            break;
            case 3:
            Instance.armoredMonsterQueue.Enqueue(allocatedMonster);
            break;
            default:
            break;
        }
        allocatedMonsterNum--;

        CheckStageEnd();
    }

    IEnumerator MakeMonsterWave(int stage, int type, int volume, float delay)
    {
        for (int i = 0; i < volume; i++)
        {
            switch(type)
            {
                case 0:
                AllocateMonster(type, (int)mobInfo[stage]["HpLight"], (int)mobInfo[stage]["ArmorLight"]);
                break;
                case 1:
                AllocateMonster(type, (int)mobInfo[stage]["HpMedium"], (int)mobInfo[stage]["ArmorMedium"]);
                break;
                case 2:
                AllocateMonster(type, (int)mobInfo[stage]["HpHeavy"], (int)mobInfo[stage]["ArmorHeavy"]);
                break;
                case 3:
                AllocateMonster(type, (int)mobInfo[stage]["HpArmored"], (int)mobInfo[stage]["ArmorArmored"]);
                break;
                default:
                break;
            }
            yield return new WaitForSeconds(delay);
        }
    }
    public void SetStageWaveInfo(int stage)
    {
        switch(stage)
        {
            case 0:
            curStageWaveInfo = CsvReader.Read ("Stage0WaveCsv");
            break;
            default:
            break;
        }
    }

    public IEnumerator StartMonsterWave(int stage)
    {
        float curTime = 0;
        float nextWaveTime;
        allocatedMonsterNum = 0;
        monsterNumNeedToCreate = 0;
        createdMonsterNum = 0;
        for(int i = 0; i < curStageWaveInfo.Count; i++)
        {
            monsterNumNeedToCreate += (int)curStageWaveInfo[i]["Volume"];
        }
        for(int i =0; i< curStageWaveInfo.Count; i++)
        {
            nextWaveTime = Convert.ToSingle(curStageWaveInfo[i]["Time"]);
            yield return new WaitForSeconds(nextWaveTime-curTime);
            curTime = nextWaveTime;
            StartCoroutine(MakeMonsterWave(stage, (int)curStageWaveInfo[i]["Type"], (int)curStageWaveInfo[i]["Volume"], Convert.ToSingle(curStageWaveInfo[i]["Delay"])));
        }
    }
}
