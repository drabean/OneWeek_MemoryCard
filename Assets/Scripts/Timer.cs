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
    /// Ÿ�̸Ӹ� �����մϴ�.
    /// </summary>
    public void StartTimer()
    {
        timerOn = true;
    }

    /// <summary>
    /// Ÿ�̸Ӹ� �����մϴ�.
    /// </summary>
    public void EndTimer()
    {
        timerOn = false;

    }
    /// <summary>
    /// Ÿ�̸��� ���� �ð��� �����ɴϴ�
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
