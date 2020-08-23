using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    float stageStartTime;
    bool isStageStart;
    Vector3 enqueuedMonsterPos = new Vector3(100, 100, 100);
    List<WayPoint> wayPointArr = new List<WayPoint>();
    List<Transform> curStageWayPoint;

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

    int stage = 0;

    void Awake()
    {
        Instance = this;
        this.isStageStart = false;
        Initialize();

        List<Dictionary<string,object>> mobTable = CSVReader.Read ("MobTableCsv");
    }

    void Start()
    {
        SetWayPoint(0);
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

        for (int i = 0; i < mediumMonsterMaxSize; i++)
        {
            if (armoredMonster != null)
                armoredMonsterQueue.Enqueue(FirstCreateNewMonster(3));
        }
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
                newMonster = Instantiate(heavyMonster).GetComponent<Armored>();
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
        calledMonster.SetMonster(type, hp, armor, curStageWayPoint);
        calledMonster.gameObject.SetActive(true);
        calledMonster.transform.position = curStageWayPoint[0].transform.position;
    }

    public void FreeMonster(Monster allocatedMonster)
    {
        int type = allocatedMonster.GetMonsterType();
        allocatedMonster.gameObject.SetActive(false);
        allocatedMonster.transform.position = enqueuedMonsterPos;

        switch(type)
        {
            case -2:
            Instance.lightMonsterQueue.Enqueue(allocatedMonster);
            break;
            case -1:
            Instance.mediumMonsterQueue.Enqueue(allocatedMonster);
            break;
            case 0:
            Instance.heavyMonsterQueue.Enqueue(allocatedMonster);
            break;
            case 1:
            Instance.armoredMonsterQueue.Enqueue(allocatedMonster);
            break;
            default:
            break;
        }
    }

    public void MakeMonsterWave(int stage, int type, int volume, float delay)
    {
        for (int i = 0; i < volume; i++)
        {
        }
    }
    void SetWayPoint(int stage)
    {
        curStageWayPoint = wayPointArr[stage].GetWayPoint();
    }
}
