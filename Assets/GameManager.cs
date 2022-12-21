using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool timerAvailable;
    public void GameStart()
    {

    }

    public void GameEnd()
    {

    }
    public void Click_Ready()
    {
        Debug.Log("Game Start");
        timerAvailable = true;
    }

    [ContextMenu("STOP")]
    public void stop()
    {
        timerAvailable = false;
    }
    
}
