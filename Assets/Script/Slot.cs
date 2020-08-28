using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IBeginDragHandler, IDragHandler, IDropHandler
{
    private Vector3 originPosition;
    [SerializeField] Image image;
    [SerializeField] int index;
    [SerializeField] Unit unit;

    private void Start()
    {
        originPosition = transform.GetChild(0).position;
    }

    public void SetUnit(Unit inputUnit) {

        if (inputUnit == null)
        {
            image.transform.localScale = Vector3.zero;
            unit = null;
            image = null;
            gameObject.name = "Null";
        }
        else
        {
            image.transform.localScale = Vector3.one;
            unit = inputUnit;
            image.sprite = inputUnit.GetComponentInChildren<SpriteRenderer>().sprite;
            gameObject.name = inputUnit.name;
        }
    }

    public void UpdateSlot()
    {
        if (unit == null)
        {
            image = null;
            gameObject.name = "Null";
        }
        else
        {
            image.sprite = unit.GetComponentInChildren<SpriteRenderer>().sprite;
            gameObject.name = unit.name;
            image.transform.localScale = Vector3.zero;
        }
    }

    public void SetIndex(int i) {
        index = i;
    }

    public int ReturnIndex() {
        return index;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        //이미지만 마우스에게 옮겨줌.
        Time.timeScale = 0.1f;
        transform.GetChild(0).position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //만약 맵 배열 확인해서 놓을 수 있다면
        //if(map(int eventData.x, int eventData.y) == 1)
        //UnitContainerManager.MoveToMapUnit(index);
        //아님 원위치
        //else
        Time.timeScale = 1f;
        if (unit != null)
        {
            transform.GetChild(0).position = transform.position;
            Vector3 positionTmp = Camera.main.ScreenToWorldPoint(eventData.position);
            positionTmp.z = 0;
            unit.transform.position = Vector3Int.RoundToInt(positionTmp);
            unit.transform.SetParent(null);
            unit = null;
            image.transform.localScale = Vector3.zero;
        }
    }
}
