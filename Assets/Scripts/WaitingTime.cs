using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitingTime : MonoBehaviour
{
    float waitTime;
    TextMeshProUGUI text_WaitingTime;

    bool isTimerOn;

    private void Awake()
    {
        text_WaitingTime = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(isTimerOn) ReduceTime();
    }

    void ReduceTime()
    {
        waitTime -= Time.deltaTime;
        text_WaitingTime.text = "그림을 기억해 주세요!! " + waitTime.ToString("N0");
        if (waitTime <= 0)
        {
            text_WaitingTime.text = "같은 그림을 찾아주세요! ";
            GameManager.Inst.timer.StartTimer();
            isTimerOn = false;
        }
    }

    public void startReduceTime()
    {
        GameManager.Inst.timer.EndTimer();
        isTimerOn = true;
        waitTime = 5.5f;
    }
}
