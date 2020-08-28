using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> stagePosition = null;
    float xAnchor = 8.0f;
    float yAnchor = 4.0f;
    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveCameraToStage(int stage)
    {
        Debug.Log("Stage " + stage);
        transform.position = new Vector3(stagePosition[stage].transform.position.x + xAnchor, stagePosition[stage].transform.position.y + yAnchor, -10);
        Debug.Log("Move Camera");
    }
}
