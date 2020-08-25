using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();


        Vector3Int cellPosition = gridLayout.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //transform.position = gridLayout.CellToWorld(cellPosition);
        Debug.Log(gridLayout.CellToWorld(cellPosition));
        //Debug.Log(transform.position);
    }
}
