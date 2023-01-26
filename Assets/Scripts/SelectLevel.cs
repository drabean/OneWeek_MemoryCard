using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] GameObject themeWindo;
    private void Start()
    {
        SoundManager.Inst.PlayBGM("StartSceneBGM");

    }
    public void Click_Easy()
    {
        Debug.Log("Easy");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        themeWindo.SetActive(true);
        //SceneManager.LoadScene("2.ReadyScene");
    }

    public void Click_Normal()
    {
        Debug.Log("Normal");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        themeWindo.SetActive(true);
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Hard()
    {

        Debug.Log("Hard");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        themeWindo.SetActive(true);
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Master()
    {
        Debug.Log("Master");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        themeWindo.SetActive(true);
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Exit()
    {
        themeWindo.SetActive(false);
    }
    public void Click_Police()
    {
        GameDatas.Inst.theme = THEME.POLICE;
        SceneManager.LoadScene("2.PoliceReadyScene");
    }

    public void Click_Doctor()
    {
        GameDatas.Inst.theme = THEME.DOCTOR;
        SceneManager.LoadScene("2.DoctorReadyScene");
    }

    public void Click_Archaeologist()
    {
        GameDatas.Inst.theme = THEME.ARCHAEOLOGIST;
        SceneManager.LoadScene("2.ArchaeologistReadyScene");
    }
}