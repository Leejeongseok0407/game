using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] GameObject unitMap;
    [SerializeField] protected float range = 4;
    [SerializeField] protected int[] gene = new int[4];
    [SerializeField] protected int unitType;
    [SerializeField] protected int skillNum;
    [SerializeField] protected float coolDownTime;
    [SerializeField] protected bool isCoolDown;

    private void Awake()
    {
        SetUnitType();
        SetUnitRange();
    }
    virtual protected void SetUnitType()
    {
        unitType = 1;
    }
    protected void SetUnitRange() {
        GetComponent<CircleCollider2D>().radius = range / 10f;

    }

    void SKill()
    {
        if (!CoolDownCheck())
            return;
        DoSkill();
        CoolDown();
    }

    bool CoolDownCheck()
    {
        return isCoolDown;
    }

    //스킬의 구현
    void DoSkill()
    {
        switch (skillNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
    //쿨타임 체크를 코루틴으로
    void CoolDown()
    {

    }

    /* protected void Start()
     {
         this.GetComponent<CircleCollider2D>().radius = range;
     }*/

    //차후에 온 콜라이더로
    void Detect() { 
    
    }

    //이건 버튼을 눌렀을때 작동 되게 생성
    void CreateSon() { 
    
    }
}
