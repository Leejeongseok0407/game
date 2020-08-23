using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GBtnType : MonoBehaviour
{

    public CanvasGroup GmainGroup;
    public CanvasGroup GoptionGroup;
    bool isSound;
    public AudioSource musicsource;
    public void OnGBtnClick(string GBTN)
    {
        switch (GBTN)
        {
            case "Option":
                CanvasGroupOn(GoptionGroup);
                CanvasGroupOff(GmainGroup);
                break;

            case "Sound":
                if (isSound)
                {
                    musicsource.volume = 0f;
                    Debug.Log("soundOFF");
                }
                else
                {
                    musicsource.volume = 1f;
                    Debug.Log("SoundOn");
                }
                isSound = !isSound;
                break;

            case "Back":
                CanvasGroupOn(GmainGroup);
                CanvasGroupOff(GoptionGroup);
                break;

            case "Quit":

                break;
        }
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
}
