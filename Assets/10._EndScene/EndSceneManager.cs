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

    //highscore�϶��� �����ִ°�
    public GameObject HighScoreImage;

    public InGameRanking inGameRanking = null;

    public int rewardStar;


    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().sortingLayerName = "UI";


        scoreText.text = GameDatas.Inst.time.ToString("N2");
        //�̸��ٲ������
        //nameTMP.text = GameData.Inst.;
        //HighScore�϶� ó�� �ؾ���
        bool isHighScore = false;
        HighScoreImage.SetActive(isHighScore);


        //���� ������ ���⼭

        switch (GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.EASY: // ��������� �� ���� ����
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
            case DIFFICULTY.NORMAL: // �븻����� �� ���� ����
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
            case DIFFICULTY.HARD: // �ϵ����� �� ���� ����
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
            case DIFFICULTY.MASTER: // �����͸���� �� ���� ����
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
        //reward ���� ���� �Լ��� ���ʿ� �߰�

        inGameRanking.EndingSceneSequnce((float)System.Math.Round((GameDatas.Inst).time,2),rewardStar,1,GameDatas.Inst.difficulty);


    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("0.StartScene");
    }


}
