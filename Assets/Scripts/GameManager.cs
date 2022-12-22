using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("게임 끝남");
        timer.EndTimer();
        GameDatas.Inst.time = timer.getTime;

        SceneManager.LoadScene("3.EndScenes", LoadSceneMode.Additive);

    }
    public void Click_Ready()
    {
        Debug.Log("Game Start");
        timer.StartTimer();
        readyBtn.SetActive(false);
    }

    
}
