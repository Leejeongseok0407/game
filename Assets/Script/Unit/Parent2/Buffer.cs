using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : Unit
{
    [SerializeField] protected int intelligence;
    [SerializeField] protected int skillNum;
    [SerializeField] protected float coolDownTime;
    [SerializeField] protected bool isCoolDown;

    //스킬을 체크-실현-쿨타임 으로 구현
    void SKill() {
        if (!coolDownCheck())
            return;
        DoSkill();
        coolDown();
    }

    //쿨다운을 반환하여 쿨타임 확인
    bool coolDownCheck() {
        return isCoolDown;
    }

    //스킬의 구현
    void DoSkill() {
        switch (skillNum) {
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
    void coolDown() { 
    
    }

}
