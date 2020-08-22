using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    public void SetUnit(Unit unit) {

        if (unit == null)
        {
            Debug.Log("Null");
            image = null;
            gameObject.name = "Null";
        }
        else {
            image.sprite = unit.GetComponentInChildren<SpriteRenderer>().sprite;
            gameObject.name = unit.name;
        }
    }

}
