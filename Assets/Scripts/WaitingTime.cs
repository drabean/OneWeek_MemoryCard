using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitingTime : MonoBehaviour
{
    float waitTime = 5f;
    TextMeshProUGUI text_WaitingTime;
    Timer timer;

    private void Awake()
    {
        text_WaitingTime = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        
    }


    public void ReduceTime()
    {
        waitTime -= Time.deltaTime;
        text_WaitingTime.text = "�׸��� ����� �ּ���!! " + waitTime.ToString("N0");
        if (waitTime <= 0)
        {
            text_WaitingTime.text = "���� �׸��� ã���ּ���! ";
            timer.StartTimer();
        }
    }
}
