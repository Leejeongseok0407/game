using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GBtnType : MonoBehaviour
{
    public static GBtnType Instance;
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
                Time.timeScale = 0;
                break;

            case "Sound":
                if (isSound)
                {
                    //musicsource.volume = 0f;
                    Debug.Log("soundOFF");
                }
                else
                {
                    //musicsource.volume = 1f;
                    Debug.Log("SoundOn");
                }
                isSound = !isSound;
                break;

            case "Resume":
                CanvasGroupOn(GmainGroup);
                CanvasGroupOff(GoptionGroup);
                Time.timeScale = 1;
                break;

            case "Quit":
                SceneManager.LoadScene(0);
                Time.timeScale = 1;

                break;

            case "Skip":
                SceneManager.LoadScene(2);

                break;
            case "NextLevel":
                StageManager.Instance.GoToNextStage();
                break;
            case "Defeat":
                StageManager.Instance.Defeat();
                break;
        }
    }

    void Start()
    {
        Instance = this;
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
