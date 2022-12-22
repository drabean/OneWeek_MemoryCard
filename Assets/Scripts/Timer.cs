using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerOn;

    public TextMeshProUGUI timeText;
    float time;
    
    /// <summary>
    /// 타이머를 시작합니다.
    /// </summary>
    public void StartTimer()
    {
        timerOn = true;
    }

    /// <summary>
    /// 타이머를 종료합니다.
    /// </summary>
    public void EndTimer()
    {
        timerOn = false;

    }
    /// <summary>
    /// 타이머의 현재 시간을 가져옵니다
    /// </summary>
    /// <returns></returns>
    public float getTime => time;

    void Update()
    {
        if (timerOn) On();
        else Stop();
    }

    void On()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    void Stop()
    {
        timeText.text = time.ToString("N2");
    }


}
