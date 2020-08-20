using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //ObjectPool은 하나만 있어야 하기 때문(싱글톤을 이용함)
    public static ObjectPool Instance;
    //새로 만들 오브젝트
    [SerializeField]
    private GameObject RangerBullet;
    [SerializeField]
    private GameObject WizardBullet;
    [SerializeField]
    private int setBulletSize = 10;
    //총알을 담을 큐
    Queue<BulletRanger> BulletRangerQueue = new Queue<BulletRanger>();
    Queue<BulletWizard> BulletWizardQueue = new Queue<BulletWizard>();



    private void Awake()
    {
        Instance = this;
        Initialize(setBulletSize);
    }

    //총알을 초기값 = initCount 의 수 만큼 생성하여 담아둠.
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            if (RangerBullet != null)
                BulletRangerQueue.Enqueue(CreateNewBulletRanger());
            if (WizardBullet != null)
                BulletWizardQueue.Enqueue(CreateNewBulletWizard());
        }
    }

    //총알을 만들고 비활성화 + 자식으로 넣어주는 시켜주는 역활
    private BulletRanger CreateNewBulletRanger()
    {
        var newObj = Instantiate(RangerBullet).GetComponent<BulletRanger>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    private BulletWizard CreateNewBulletWizard()
    {
        var newObj = Instantiate(WizardBullet).GetComponent<BulletWizard>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }


    //요청한 자에게 꺼내주는 함수
    public static BulletRanger GetBulletRanger()
    {
        //총알이 있으면 총알을 할당해줌.
        if (Instance.BulletRangerQueue.Count > 0)
        {
            var obj = Instance.BulletRangerQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        //총알이 없으면 총알 생성해줌.
        else
        {
            var newObj = Instance.CreateNewBulletRanger();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }
    public static BulletWizard GetBulletWizard()
    {
        //총알이 있으면 총알을 할당해줌.
        if (Instance.BulletWizardQueue.Count > 0)
        {
            var obj = Instance.BulletWizardQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        //총알이 없으면 총알 생성해줌.
        else
        {
            var newObj = Instance.CreateNewBulletWizard();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }


    //반환해주는 함수
    public static void ReturnBulletRanger(BulletRanger obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.BulletRangerQueue.Enqueue(obj);
    }

    public static void ReturnBulletWizard(BulletWizard obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.BulletWizardQueue.Enqueue(obj);
    }
}