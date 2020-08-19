using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullitRanger : Bullit
{

    private void Update()
    {
        MoveBullit();
        RemoveBullit();
    }
    
}
