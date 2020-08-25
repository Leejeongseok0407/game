using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //ObjectPool은 하나만 있어야 하기 때문(싱글톤을 이용함)
    public static ObjectPool ObjectPoolInstance;
    //새로 만들 오브젝트
    [SerializeField]
    private GameObject bulletRanger = null;
    [SerializeField]
    private GameObject bulletWizard = null;
    [SerializeField]
    private int setBulletSize = 10;
    //총알을 담을 큐
    Queue<Bullet> BulletRangerQueue = new Queue<Bullet>();
    Queue<Bullet> BulletWizardQueue = new Queue<Bullet>();



    private void Awake()
    {
        ObjectPoolInstance = this;
        Initialize(setBulletSize);
    }

    //총알을 초기값 = initCount 의 수 만큼 생성하여 담아둠.
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            if (bulletRanger != null)
                BulletRangerQueue.Enqueue(CreateNewBullet(0));
            if (bulletWizard != null)
                BulletWizardQueue.Enqueue(CreateNewBullet(1));
            else
                Debug.Log("불릿을 할당해 주세요");
        }
    }
    private Bullet CreateNewBullet(int type)
    {
        if (type == 0)
        {
            var newRangerBullet = Instantiate(bulletRanger).GetComponent<BulletRanger>();
            newRangerBullet.gameObject.SetActive(false);
            newRangerBullet.transform.SetParent(transform);
            return newRangerBullet;
        }
        else if (type == 1)
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
        }
    }

    //요청한 자에게 꺼내주는 함수
    public static Bullet GetBullet(GameObject callObject, int type)
    {

        if (type == 0)
        {
            //총알이 있으면 총알을 할당해줌.
            if (ObjectPoolInstance.BulletRangerQueue.Count > 0)
            {
                var obj = ObjectPoolInstance.BulletRangerQueue.Dequeue();
                obj.transform.position = callObject.transform.position;
                obj.transform.SetParent(callObject.transform);
                obj.gameObject.SetActive(true);
                return obj;
            }
            //총알이 없으면 총알 생성해줌.
            else
            {
                var newObj = ObjectPoolInstance.CreateNewBullet(type);
                newObj.transform.position = callObject.transform.position;
                newObj.gameObject.SetActive(true);
                newObj.transform.SetParent(callObject.transform);
                return newObj;
            }
        }
        else if (type == 1)
        {
            //총알이 있으면 총알을 할당해줌.
            if (ObjectPoolInstance.BulletWizardQueue.Count > 0)
            {
                var obj = ObjectPoolInstance.BulletWizardQueue.Dequeue();
                obj.transform.position = callObject.transform.position;
                obj.transform.SetParent(callObject.transform);
                obj.gameObject.SetActive(true);
                return obj;
            }
            //총알이 없으면 총알 생성해줌.
            else
            {
                var newObj = ObjectPoolInstance.CreateNewBullet(type);
                newObj.transform.position = callObject.transform.position;
                newObj.gameObject.SetActive(true);
                newObj.transform.SetParent(callObject.transform);
                return newObj;
            }
        }
        else
        {
            Debug.Log("잘못된 타입");
            return null;
        }
    }


    //반환해주는 함수
    public static void ReturnBullet(Bullet obj, int type)
    {
        if (type == 0)
        {
            obj.gameObject.SetActive(false);
            obj.transform.position = ObjectPoolInstance.gameObject.transform.position;
            obj.transform.SetParent(ObjectPoolInstance.transform);
            ObjectPoolInstance.BulletRangerQueue.Enqueue(obj);
        }
        else if (type == 1)
        {
            obj.gameObject.SetActive(false);
            obj.transform.position = ObjectPoolInstance.gameObject.transform.position;
            obj.transform.SetParent(ObjectPoolInstance.transform);
            ObjectPoolInstance.BulletWizardQueue.Enqueue(obj);
        }
    }


}

