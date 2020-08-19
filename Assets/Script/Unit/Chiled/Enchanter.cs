using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchanter : Buffer
{

    /*
    # gene[4] : int = {0,0,1,0}
    # unitType : int  = 2
    # skillNum : int = 0~2
    */
    private void Awake()
    {
        unitType = 2;
    }
}
