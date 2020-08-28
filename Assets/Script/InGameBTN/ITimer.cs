using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ITimer : MonoBehaviour
{
    float _Sec;
    int _Min;

    [SerializeField]
    Text _Timertext;

    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        _Sec += Time.deltaTime;

        _Timertext.text = string.Format("{0:D2}:{1:D2}", _Min, (int)_Sec);

        if((int)_Sec > 59)
        {
            _Sec = 0;
            _Min++;
        }
    }
}
