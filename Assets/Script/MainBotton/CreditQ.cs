using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditQ : MonoBehaviour
{
    public CanvasGroup mainGroup;
    public CanvasGroup creditGroup;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Scenechange", 10f);
        CanvasGroupOn(mainGroup);
        CanvasGroupOff(creditGroup);
    }

    private void Scenechange()
    {
        CanvasGroupOn(mainGroup);
        CanvasGroupOff(creditGroup);
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    // Update is called once per frame
}
