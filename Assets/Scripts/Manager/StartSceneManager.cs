using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Inst.PlayBGM("BGM_StartScene");

    }
    public void Click_Easy()
    {
        Debug.Log("Easy");
        SoundManager.Inst.PlaySFX("SFX_Click");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        SceneManager.LoadScene("1.SelectModeScene");
        //SceneManager.LoadScene("2.ReadyScene");
    }

    public void Click_Normal()
    {
        Debug.Log("Normal");
        SoundManager.Inst.PlaySFX("SFX_Click");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        SceneManager.LoadScene("1.SelectModeScene");
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Hard()
    {

        Debug.Log("Hard");
        SoundManager.Inst.PlaySFX("SFX_Click");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        SceneManager.LoadScene("1.SelectModeScene");
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Master()
    {
        Debug.Log("Master");
        SoundManager.Inst.PlaySFX("SFX_Click");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        SceneManager.LoadScene("1.SelectModeScene");
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Exit()
    {
        // 끝내는 버튼 눌렀을 시 나오게 
    }
    public void Click_Police()
    {
        GameDatas.Inst.theme = THEME.POLICE;
        GameDatas.Inst.scene = SCENE.READY;
        SoundManager.Inst.PlayBGM("BGM_Police");
        SceneManager.LoadScene("2.PoliceReadyScene");
    }

    public void Click_Doctor()
    {
        GameDatas.Inst.theme = THEME.DOCTOR;
        GameDatas.Inst.scene = SCENE.READY;
        SoundManager.Inst.PlayBGM("BGM_Police");
        SceneManager.LoadScene("2.DoctorReadyScene");
    }

    public void Click_Archaeologist()
    {
        GameDatas.Inst.theme = THEME.ARCHAEOLOGIST;
        GameDatas.Inst.scene = SCENE.READY;
        SoundManager.Inst.PlayBGM("BGM_Police");
        SceneManager.LoadScene("2.ArchaeologistReadyScene");
    }
}