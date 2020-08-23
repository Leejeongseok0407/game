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
            slot.SetIndex(i);
            if (i < UnitContainer.ReadUnitArry().Count)
                slot.SetUnit(UnitContainer.ReadUnitArry()[i]);
            else
                slot.SetUnit(null);
            slots.Add(slot);
        }
    }
    
}
