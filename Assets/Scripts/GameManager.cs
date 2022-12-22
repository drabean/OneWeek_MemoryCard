using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    public GameObject readyBtn;
    public Timer timer;

    public void Awake()
    {
        Inst = this;
    }


    public void GameStart()
    {

    }

    public void GameEnd()
    {
        Debug.Log("���� ����");
        timer.TimerStop();
    }
    public void Click_Ready()
    {
        Debug.Log("Game Start");
        timer.StartTimer();
        readyBtn.SetActive(false);
    }

    
}
