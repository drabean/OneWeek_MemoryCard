using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    public GameObject readyBtn;
    public Timer timer;
    public WaitingTime waitingTime;

    public void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        StartCoroutine(CO_Ready());
    }
    public void GameEnd()
    {
        Debug.Log("게임 끝남");
        timer.EndTimer();
        GameDatas.Inst.time = timer.getTime;

        Destroy(timer.gameObject);

        SceneManager.LoadScene("3.EndScenes", LoadSceneMode.Additive);

    }
    IEnumerator CO_Ready()
    {

        yield return new WaitForSeconds(3);
        CardManager.Inst.resetStage();
        waitingTime.startReduceTime();

        readyBtn.SetActive(false);
    }

    
}
