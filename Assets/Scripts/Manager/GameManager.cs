using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    public GameObject readyBtn;
    public GameObject firstTextImage;
    public GameObject secondTextImage;
    public Timer timer;
    public WaitingTime waitingTime;
    public void Awake()
    {
        if (Inst == null) Inst = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(CO_Ready());
    }


    public void GameEnd()
    {
        timer.EndTimer();
        GameDatas.Inst.time = timer.getTime;

        Destroy(timer.gameObject);
    }
    IEnumerator CO_Ready()
    {

        yield return new WaitForSeconds(3);
        CardManager.Inst.resetStage();
        waitingTime.startReduceTime();
        readyBtn.SetActive(false);
        
    }

    public void ChangeTextImage()
    {
        firstTextImage.SetActive(false);
        secondTextImage.SetActive(true);
    }

    public void EndApplication()
    {
        Debug.Log("ENDGAME");
        //Application.Quit();
        SceneManager.LoadScene("0.StartSCene");
    }
    
}
