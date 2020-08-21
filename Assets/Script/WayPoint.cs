using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    
    public List<Transform> GetWayPoint()
    {
        return points;
    } 
}
