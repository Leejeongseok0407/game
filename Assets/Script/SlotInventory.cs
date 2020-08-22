using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInventory : MonoBehaviour
{
    [SerializeField] UnitContainerManager UnitContainer;
    [SerializeField] Transform slotRoot;
    [SerializeField] List<Slot> slots;


    private void Start()
    {
        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();
            if (i < UnitContainer.unitInventoryArry.Count)
                slot.SetUnit(UnitContainer.unitInventoryArry[i]);
            else
                slot.SetUnit(null);
            slots.Add(slot);
        }
    }

}
