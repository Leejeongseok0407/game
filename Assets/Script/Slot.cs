using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    private Vector3 originPosition;
    [SerializeField] Image image;
    [SerializeField] int index;
    [SerializeField] Unit units;

    public void SetUnit(Unit inputUnit) {

        if (inputUnit == null)
        {
            Debug.Log("Null");
            units = null;
            image = null;
            gameObject.name = "Null";
        }
        else
        {
            units = inputUnit;
            image.sprite = inputUnit.GetComponentInChildren<SpriteRenderer>().sprite;
            gameObject.name = inputUnit.name;
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
        originPosition = transform.position;
        Debug.Log("*");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //이미지만 마우스에게 옮겨줌.
        Debug.Log("*");
        transform.GetChild(0).position = transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //놓을수 있는지 판단해서 만약 놓을 수 있으면

        //유닛 인벤에서 맵 인벤으로
        //그리고 인벤토리 업데이트

        // transform.position = originPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
