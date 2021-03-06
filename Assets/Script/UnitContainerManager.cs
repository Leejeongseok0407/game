﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitContainerManager : MonoBehaviour
{
    [SerializeField] GameObject unitMap;
    [SerializeField] GameObject unitInventory;

    [SerializeField] SlotInventory slotInventory;

    [SerializeField] List<Unit> unitMapArry;
    [SerializeField] List<Unit> unitInventoryArry;

    public static UnitContainerManager Instance;
    private void Awake()
    {
        Instance = this;
        SetArry();
    }

    public GameObject ReturnUnitMap()
    {
        return unitMap;
    }
    public GameObject ReturnunitInventory()
    {
        return unitInventory;
    }

    public void SetArry() {
        for (int i = 0; i < unitInventory.transform.childCount; i++)
        {
            var setUnitInventory = unitInventory.transform.GetChild(i).GetComponent<Unit>();

            unitInventoryArry.Add(setUnitInventory);
        }
        for (int i = 0; i < unitMap.transform.childCount; i++)
        {
            var setUnitMap = unitMap.transform.GetChild(i).GetComponent<Unit>();

            unitMapArry.Add(setUnitMap);
        }
    }

    void InsertMap(Unit unit) {
        //유닛 놓을 수 있는지 체크
        //유닛 포지션 지정
        unit.transform.SetParent(unitMap.transform);
        unitMapArry.Add(unit);
        unitInventoryArry.Remove(unit);
    }

    public List<Unit> ReadUnitArry()
    {
        return unitInventoryArry;
    }

    public GameObject ReturnunitMap() {
        return unitMap;
    }


    public void ReturnUnit(Unit obj)
    {
        Debug.Log("Retunr");
        obj.transform.position = unitInventory.gameObject.transform.position;
        obj.transform.SetParent(unitInventory.transform);
        unitInventoryArry.Add(obj);
    }

    public void MoveToMapUnit(int index, Vector3 position)
    {
        if (unitInventory.transform.GetChild(index) != null)
        {
            position.z = 0;
            Debug.Log("position");
            unitInventory.transform.GetChild(index).transform.position = position;
            unitInventory.transform.GetChild(index).SetParent(unitMap.transform);
            slotInventory.UpdateInventory();
        }
        else
            Debug.Log("에러");
    }

    public void ResetUnnit()
    {
        while (unitMap.transform.childCount != 0)
        {
            var setUnitMap = unitMap.transform.GetChild(0).GetComponent<Unit>();
            setUnitMap.transform.SetParent(unitInventory.transform);
        }

        unitInventoryArry = new List<Unit>();
        unitMapArry = new List<Unit>();
        for (int i = 0; i < unitInventory.transform.childCount; i++)
        {
            var setUnitInventory = unitInventory.transform.GetChild(i).GetComponent<Unit>();
            unitInventoryArry.Add(setUnitInventory);
        }
        for (int i = 0; i < unitMap.transform.childCount; i++)
        {
            var setUnitMap = unitMap.transform.GetChild(i).GetComponent<Unit>();
            unitMapArry.Add(setUnitMap);
        }
    }
}
