using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI nameTMP;
    [SerializeField] Text scoreText;
    [SerializeField] Text rewardStarText;

    //highscore일때만 보여주는거
    public GameObject HighScoreImage;

    public InGameRanking inGameRanking = null;

    public int rewardStar;


    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().sortingLayerName = "UI";


        scoreText.text = GameDatas.Inst.time.ToString("N2");
        //이름바꿔줘야함
        //nameTMP.text = GameData.Inst.;
        //HighScore일때 처리 해아함
        bool isHighScore = false;
        HighScoreImage.SetActive(isHighScore);


        //보상 변경은 여기서

        switch (GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.EASY: // 이지모드일 때 보상 지급
                switch (GameDatas.Inst.time)
                {
                    case (<= 3):
                        rewardStar = 12;
                        break;
                    case (<= 6):
                        rewardStar = 8;
                        break;
                    default:
                        rewardStar = 5;
                        break;
                }
                break;
            case DIFFICULTY.NORMAL: // 노말모드일 때 보상 지급
                switch (GameDatas.Inst.time)
                {
                    case (<= 5):
                        rewardStar = 12;
                        break;
                    case (<= 10):
                        rewardStar = 8;
                        break;
                    default:
                        rewardStar = 5;
                        break;
                }
                break;
            case DIFFICULTY.HARD: // 하드모드일 때 보상 지급
                switch (GameDatas.Inst.time)
                {
                    case (<= 20):
                        rewardStar = 12;
                        break;
                    case (<= 30):
                        rewardStar = 8;
                        break;
                    default:
                        rewardStar = 5;
                        break;
                }
                break;
            case DIFFICULTY.MASTER: // 마스터모드일 때 보상 지급
                switch (GameDatas.Inst.time)
                {
                    case (<= 80):
                        rewardStar = 12;
                        break;
                    case (<= 180):
                        rewardStar = 8;
                        break;
                    default:
                        rewardStar = 5;
                        break;
                }
                break;
        }



        rewardStarText.text = "X"+rewardStar;
        //reward 실제 변경 함수는 이쪽에 추가

        inGameRanking.EndingSceneSequnce((float)System.Math.Round((GameDatas.Inst).time,2),rewardStar,1,GameDatas.Inst.difficulty);


    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("0.StartScene");
    }


}
