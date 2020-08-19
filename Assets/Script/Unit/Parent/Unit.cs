using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected float range;
    [SerializeField] protected int[] gene = new int[4];
    [SerializeField] protected int unitType;

    void SKill()
    {
        if (!CoolDownCheck())
            return;
        DoSkill();
        CoolDown();
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
