using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitingTime : MonoBehaviour
{
    float waitTime;
    TextMeshProUGUI text_WaitingTime;

    bool isTimerOn;

   [SerializeField]  AudioSource AS;
    public AudioClip[] clips;


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
        text_WaitingTime.text = "�׸��� ����� �ּ���!! " + waitTime.ToString("N0");
        if (waitTime <= 0)
        {
            text_WaitingTime.text = "���� �׸��� ã���ּ���! ";
            GameManager.Inst.timer.StartTimer();
            isTimerOn = false;
            AS.Stop();

            AS.clip = clips[1];
            AS.Play();

        }
    }

    public void startReduceTime()
    {
        GameManager.Inst.timer.EndTimer();
        isTimerOn = true;
        waitTime = 5.5f;

        AS.clip = clips[0];
        AS.Play();
    }
}
