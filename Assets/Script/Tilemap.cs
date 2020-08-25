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
 
    }

    public Vector3 GetTilePositionByIndex(int row, int col)
    {
        float tilePositionX = transform.position.x + 5 - row;
        float tilePositionY = transform.position.y + col - 10;
        return new Vector3(tilePositionX, tilePositionY, 0);
    }
}
