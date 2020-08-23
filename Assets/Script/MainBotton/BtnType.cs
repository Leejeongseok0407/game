using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BtnType : MonoBehaviour
{
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup creditGroup;
    bool isSound;
    public AudioSource musicsource;

    public void OnBtnClick(string BTN)
    {
        switch (BTN)
        {
            case "Start":
                UnityEngine.Debug.Log("새게임");
                break;
            case "Option":
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                UnityEngine.Debug.Log("설정");
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
            //소리사용시 수정해야함
            case "Back":
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                UnityEngine.Debug.Log("뒤로");
                break;
            case "Credit":
                CanvasGroupOn(creditGroup);
                CanvasGroupOff(mainGroup);
                UnityEngine.Debug.Log("크레딧");
                break;
            case "Quit":
                Application.Quit();
                UnityEngine.Debug.Log("종료");
                break;
            case "Quitcredit":
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(creditGroup);
                Application.Quit();
                UnityEngine.Debug.Log("시작화면");
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
