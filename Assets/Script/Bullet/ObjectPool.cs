using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //ObjectPool은 하나만 있어야 하기 때문(싱글톤을 이용함)
    public static ObjectPool Instance;
    //새로 만들 오브젝트
    [SerializeField]
    private GameObject bulletRanger = null;
    [SerializeField]
    private GameObject bulletWizard = null;
    [SerializeField]
    private int setBulletSize = 10;
    //총알을 담을 큐
    Queue<Bullet> BulletRangerQueue = new Queue<Bullet>();
//    Queue<Bullet> BulletWizardQueue = new Queue<Bullet>();



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
            if (bulletRanger != null)
                BulletRangerQueue.Enqueue(FirstCreateNewBullet(0));/*
            if (bulletWizard != null)
                BulletRangerQueue.Enqueue(FirstCreateNewBullet(1));*/
            else
                Debug.Log("불릿을 할당해 주세요");
        }
    }
    private Bullet FirstCreateNewBullet(int type)
    {
        
            var newRangerBullet = Instantiate(bulletRanger).GetComponent<BulletRanger>();
            newRangerBullet.gameObject.SetActive(false);
            newRangerBullet.transform.SetParent(transform);
            return newRangerBullet;
       /* else if (type == 1)
        {
            var newWizardBullet = Instantiate(bulletWizard).GetComponent<BulletWizard>();
            newWizardBullet.gameObject.SetActive(false);
            newWizardBullet.transform.SetParent(transform);
            return newWizardBullet;
        }
        else
        {
            Debug.Log("잘못된 오브젝트");
            return null;
        }*/
    }

    //총알을 만들고 비활성화 + 자식으로 넣어주는 시켜주는 역활
    private Bullet CreateNewBullet(GameObject callObject)
    {
        
            var newRangerBullet = Instantiate(bulletRanger).GetComponent<BulletRanger>();
            newRangerBullet.gameObject.SetActive(false);
            newRangerBullet.transform.SetParent(transform);
            return newRangerBullet;
        /*else if (callObject.GetComponent<Wizard>() != null)
        {
            var newWizardBullet = Instantiate(bulletWizard).GetComponent<BulletWizard>();
            newWizardBullet.gameObject.SetActive(false);
            newWizardBullet.transform.SetParent(transform);
            return newWizardBullet;
        }
        else
        {
            Debug.Log("잘못된 오브젝트");
            return null;
        }*/
    }

    //요청한 자에게 꺼내주는 함수
    public static Bullet GetBullet(GameObject callObject)
    {
        Debug.Log("GetBullet");

        //총알이 있으면 총알을 할당해줌.
        if (Instance.BulletRangerQueue.Count > 0)
        {
            var obj = Instance.BulletRangerQueue.Dequeue();
            obj.transform.position = callObject.transform.position;
            obj.transform.SetParent(callObject.transform);
            obj.gameObject.SetActive(true);
            return obj;
        }
        //총알이 없으면 총알 생성해줌.
        else
        {
            var newObj = Instance.CreateNewBullet(callObject);
            newObj.transform.position = callObject.transform.position;
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(callObject.transform);
            return newObj;
        }
        /*else if (callObject.GetComponent<Wizard>() != null)
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
                var newObj = Instance.CreateNewBullet(callObject);
                newObj.gameObject.SetActive(true);
                newObj.transform.SetParent(null);
                return newObj;
            }
        }*/

    }


    //반환해주는 함수
    public static void ReturnBullet(Bullet obj)
    {
        Debug.Log("Retunr");
        obj.gameObject.SetActive(false);
        obj.transform.position = Instance.gameObject.transform.position;
        obj.transform.SetParent(Instance.transform);
        Instance.BulletRangerQueue.Enqueue(obj);
    }/*
        else if (obj.GetComponent<BulletWizard>() != null)
        {
            obj.gameObject.SetActive(false);
            obj.transform.position = Instance.gameObject.transform.position;
            obj.transform.SetParent(Instance.transform);
            Instance.BulletWizardQueue.Enqueue(obj);
        }*/
}

