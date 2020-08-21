using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    Vector3 enqueuedMonsterPos = new Vector3(100, 100, 100);
    List<GameObject> wayPointArr = new List<GameObject>();
    [SerializeField]
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

    void Awake()
    {
        Instance = this;
        Initialize();
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
                lightMonsterQueue.Enqueue(FirstCreateNewMonster(1));
        }

        for (int i = 0; i < mediumMonsterMaxSize; i++)
        {
            if (mediumMonster != null)
                lightMonsterQueue.Enqueue(FirstCreateNewMonster(2));
        }

        for (int i = 0; i < mediumMonsterMaxSize; i++)
        {
            if (mediumMonster != null)
                lightMonsterQueue.Enqueue(FirstCreateNewMonster(3));
        }
    }

    private Monster FirstCreateNewMonster(int type)
    {
        switch(type)
        {
            case 0:
                var newLightMonster = Instantiate(lightMonster).GetComponent<Light>();
                newLightMonster.gameObject.SetActive(false);
                newLightMonster.transform.position = enqueuedMonsterPos;
                return newLightMonster;
            case 1:
                var newMediumMonster = Instantiate(mediumMonster).GetComponent<Medium>();
                newMediumMonster.gameObject.SetActive(false);
                newMediumMonster.transform.position = enqueuedMonsterPos;
                return newMediumMonster;
            case 2:
                var newHeavyMonster = Instantiate(mediumMonster).GetComponent<Heavy>();
                newHeavyMonster.gameObject.SetActive(false);
                newHeavyMonster.transform.position = enqueuedMonsterPos;
                return newHeavyMonster;
            case 3:
                var newArmoredMonster = Instantiate(mediumMonster).GetComponent<Armored>();
                newArmoredMonster.gameObject.SetActive(false);
                newArmoredMonster.transform.position = enqueuedMonsterPos;
                return newArmoredMonster;
            default:
                Debug.Log("not valid type");
                return null;
        }
    }
    
    public void SetMonster(int type)   //
    {
        switch(type)
        {
            case 0:
                var calledLightMonster = Instance.lightMonsterQueue.Dequeue();
                calledLightMonster.gameObject.SetActive(true);
                calledLightMonster.transform.position = curStageWayPoint[0].transform.position;
                break;
            case 1:
                var calledMediumMonster = Instance.mediumMonsterQueue.Dequeue();
                calledMediumMonster.gameObject.SetActive(true);
                calledMediumMonster.transform.position = curStageWayPoint[0].transform.position;
                break;
            case 2:
                var calledHeavyMonster = Instance.heavyMonsterQueue.Dequeue();
                calledHeavyMonster.gameObject.SetActive(true);
                calledHeavyMonster.transform.position = curStageWayPoint[0].transform.position;
                break;
            case 3:
                var calledArmoredMonster = Instance.armoredMonsterQueue.Dequeue();
                calledArmoredMonster.gameObject.SetActive(true);
                calledArmoredMonster.transform.position = curStageWayPoint[0].transform.position;
                break;
            default:
                Debug.Log("not valid type");
                break;
        }
    }

    void SetWayPoint(int stage)
    {
        curStageWayPoint = wayPointArr[stage].GetComponent<WayPoint>().GetWayPoint();
    }
}
