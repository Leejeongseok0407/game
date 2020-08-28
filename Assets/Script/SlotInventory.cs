using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInventory : MonoBehaviour
{
    [SerializeField] UnitContainerManager UnitContainer;
    [SerializeField] Transform slotRoot;
    [SerializeField] List<Slot> slots;

    public static SlotInventory Instance;
    private void Start()
    {
        Instance = this;
        SetSlotInventory();
    }

    public void SetSlotInventory() {

        for (int i = 0; i < slotRoot.childCount; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();
            slot.SetIndex(i);
            if (i < UnitContainer.ReadUnitArry().Count)
            {
                slot.SetUnit(UnitContainer.ReadUnitArry()[i]);
                slot.GetComponent<Slot>().SetUnitMap(UnitContainer.ReturnUnitMap());
            }
            else
                slot.SetUnit(null);

            slots.Add(slot);
        }
    }

    public void UpdateInventory()
    {
        Debug.Log("Update");
        for (int i = 0; i < slots.Count; i++)
        {
            slotRoot.GetChild(i).GetComponent<Slot>().UpdateSlot();
        }
    }

    public void InventoryReset() {
        UnitContainer.ResetUnnit();
        SetSlotInventory();
    }
}
