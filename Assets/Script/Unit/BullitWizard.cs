using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullitWizard : Bullit
{
    private void Update()
    {
        MoveBullit();
        RemoveBullit();
    }
}
