using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    bool isSound;

    public void OnBtnClick() 
    {
        switch (currentType) 
        {
            case BTNType.Start:
                UnityEngine.Debug.Log("새게임");
                break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                UnityEngine.Debug.Log("설정");
                break;

            case BTNType.Sound:
                UnityEngine.Debug.Log("소리");
                break;
                //소리사용시 수정해야함
            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                UnityEngine.Debug.Log("뒤로");
                break;
            case BTNType.Credit:
                UnityEngine.Debug.Log("크레딧");
                break;
            case BTNType.Quit:
                Application.Quit();
                UnityEngine.Debug.Log("종료");
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
