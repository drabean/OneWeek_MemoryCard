using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI timeText;
    public float time;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.timerAvailable) TimerStart();
        else TimerStop();
    }

    public void TimerStart()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    public void TimerStop()
    {
        time += 0;
        timeText.text = time.ToString("N2");
    }
}
