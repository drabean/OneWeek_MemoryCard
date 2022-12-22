using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerOn;

    public TextMeshProUGUI timeText;
    float time;

    public void StartTimer()
    {
        timerOn = true;
    }

    public void EndTimer()
    {
        timerOn = false;

    }
    public float getTime()
    {
        return time;
    }

    void Update()
    {
        if (timerOn) TimerOn();
        else TimerStop();
    }

    public void TimerOn()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    public void TimerStop()
    {
        timeText.text = time.ToString("N2");
    }
}
