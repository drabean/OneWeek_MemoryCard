using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Inst.PlayBGM("StartSceneBGM");

    }
    public void Click_Easy()
    {
        Debug.Log("Easy");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Normal()
    {
        Debug.Log("Normal");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Hard()
    {

        Debug.Log("Hard");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Master()
    {
        Debug.Log("Master");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        //SceneManager.LoadScene("2.GameScene");
    }
}