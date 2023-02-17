using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI Text_Difficulty;
    public TextMeshProUGUI Text_Time;

    private void Start()
    {
        changeMessage();
    }

    public void changeMessage()
    {
        Text_Time.text = GameDatas.Inst.time.ToString("N2");

        string difficultyText;

        switch (GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.EASY:
                difficultyText = "Easy";
                break;
            case DIFFICULTY.NORMAL:
                difficultyText = "Normal";
                break;
            case DIFFICULTY.HARD:
                difficultyText = "Hard";
                break;
            case DIFFICULTY.MASTER:
                difficultyText = "Master";
                break;

            default:
                difficultyText = "ERROR?";
                break;
        }

        Text_Difficulty.text = difficultyText;
    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        Destroy(CommonUI.Inst.gameObject);
        SceneManager.LoadScene("0.StartScene");
    }
}
