using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    const int balloonNum = 0;
    const int memoryCardNum = 1;
    const int juiceNum = 2;
    const int puzzleNum = 3;

    const int easyDif = 0;
    const int nomalDif = 0;
    const int hardDif = 0;
    const int veryhardDif = 0;

    #region Refrence Member

    [Header("======Ref Ui======")]
    [SerializeField] private GameObject rankingBoard = null;
    [SerializeField] private EndSceneManager endSceneManager = null;


    #endregion

    #region Member

    private List<UiScore> contents = new List<UiScore>();

    private string _id = null;
    private string curGameName = null;
    private int curGameNum = 0;
    private int curDifNum = 0;
    private float curScore = 0;
    private int star = 0;

    #endregion

    public void EndingSceneSequnce(float curScore, int star, int curGameNum, DIFFICULTY dif)
    {
        endSceneManager.nameTMP.text = "�ҷ����� ��... ";

        StartCoroutine(CompareUserID(curScore, star, curGameNum, dif));
    }

    IEnumerator CompareUserID(float curScore, int star, int curGameNum, DIFFICULTY dif)
    {
        string idStr = LoginSave.Get().id;

       yield return new WaitUntil(() => idStr != null);


        SetGameInfo(idStr,curScore, star,curGameNum,dif);
    }

    ///////////////////////////���� ���� ���� ����///////////////////////////////////////////// step 1
    private void SetGameInfo(string id ,float curScore, int star ,int curGameNum, DIFFICULTY dif) 
    {
        int difNum = 0;

        switch (dif)
        {
            case DIFFICULTY.EASY: difNum = 0; break;
            case DIFFICULTY.NORMAL: difNum = 1; break;
            case DIFFICULTY.HARD: difNum = 2; break;
            case DIFFICULTY.MASTER: difNum = 3; break;
        }

        this._id = id;
        this.star = star;
        this.curScore = curScore;
        this.curGameNum = curGameNum;
        this.curDifNum = difNum;

        SaveScore();
    }



    ///////////////////////////��ŷ ���� �� ������ ��///////////////////////////////////////////// step 2
    private void SaveScore()
    {
        StartCoroutine(SaveScoreFromDatabase());
    }
    ///////////////////////////��ü ��ŷ �ҷ��� ��//////////////////////////////////////////////// uiŬ�� ��
    public void CallRanking(string id, string gameName)
    {
        _id = id;
        TypeOfGameRangking.Inst.CallRangking();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////

    //������ ���̺� �� Uiǥ�� ����
    private IEnumerator SaveScoreFromDatabase()
    {
        bool saveCheck = false;

        TypeOfGameRangking.Inst.GetUserData_FromDatabase(_id);

        yield return new WaitUntil(() => !TypeOfGameRangking.Inst.isProcessing);

        endSceneManager.nameTMP.text = TypeOfGameRangking.Inst.loginUser.nickname;


        float score = float.Parse(TypeOfGameRangking.Inst.loginUser.score[curGameNum * 4 + curDifNum]);

        if (curGameNum == 1 || curGameNum == 3)
        {
            if (score > curScore ||
                score == 0)
            {
                saveCheck = true;
            }
        }
        else
        {
            if (score < curScore ||
                score == 0)
            {
                saveCheck = true;
            }
        }


        if (saveCheck)
        {
            endSceneManager.HighScoreImage.SetActive(true);
        }
        else
        {
            curScore = score;
        }

        TypeOfGameRangking.Inst.Save_FromDatabase(_id, curScore, star, curGameNum, curDifNum);

    }


    #region Btn Event

    public void OnClick_RankingBoard()
    {
        rankingBoard.SetActive(true);


        CallRanking(_id, curGameName);
    }
    public void OnClick_Exit()
    {
        rankingBoard.SetActive(false);
    }
 

    #endregion

}
