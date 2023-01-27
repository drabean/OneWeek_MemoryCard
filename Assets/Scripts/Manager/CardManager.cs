using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst;

    public GameObject[] CardPrefab;
    public GameObject[] BoardPrefabs;
    public GameObject selectCard;
    int boardIdx; // 게임보드 선정을 위한 인덱스
    public List<Card> cards;

    int difficulty;
    float normalScale = 0.7f;
    float hardScale = 0.6f;
    float masterScale = 0.5f;
    GameBoard board;

    public Card curCard1;
    public Card curCard2;

    int stageCount;

    public FireHose hose;

    public GameObject UI_ready;

    public GameObject EndBtn;
    private void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        SoundManager.Inst.PlayBGM("InGameBGM");

        switch (GameDatas.Inst.theme)
        {
            case THEME.POLICE:
                selectCard = CardPrefab[0];
                boardIdx = 0;
                break;
            case THEME.DOCTOR:
                selectCard = CardPrefab[1];
                boardIdx = 4;
                break;
            case THEME.ARCHAEOLOGIST:
                selectCard = CardPrefab[2];
                boardIdx = 8;
                break;
        }

        switch (GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.EASY:
                difficulty = 6;
                board = Instantiate(BoardPrefabs[boardIdx], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                break;
            case DIFFICULTY.NORMAL:
                board = Instantiate(BoardPrefabs[boardIdx + 1], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 12;
                break;
            case DIFFICULTY.HARD:
                board = Instantiate(BoardPrefabs[boardIdx + 2], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 18;
                break;
            case DIFFICULTY.MASTER:
                board = Instantiate(BoardPrefabs[boardIdx + 3], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 24;
                break;
        }
        stageCount = 4;

        //resetStage();
    }
    #region Stage

    public void resetStage()
    {
        stageCount--;
        if (stageCount < 0)
        {
            Destroy(EndBtn);
            GameManager.Inst.GameEnd();
        }
        else StartCoroutine(CO_RestartStage());
    }

    public void endStage()
    {
        StartCoroutine(CO_RestartStage());
    }

    IEnumerator CO_RestartStage()
    {
        generateCard();
        suffleCard();

        board.setCardsPosition(cards);

        GameManager.Inst.waitingTime.startReduceTime();

        //여기서 카드 다 뒤집고 보여주기
        allChangeCard(true);
        yield return new WaitForSeconds(5.0f);
        //여기서 카드 다시 다 뒤집고 게임 시작하기.
        allChangeCard(false);

    }

    #endregion Stage

    #region Card Logic
    public void generateCard()
    {
        for (int i = 0; i < difficulty / 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Card temp = Instantiate(selectCard).GetComponent<Card>();
                switch (GameDatas.Inst.difficulty)
                {
                    case DIFFICULTY.EASY:
                        break;
                    case DIFFICULTY.NORMAL:
                        temp.transform.localScale = Vector3.one * normalScale;
                        break;
                    case DIFFICULTY.HARD:
                        temp.transform.localScale = Vector3.one * hardScale;
                        break;
                    case DIFFICULTY.MASTER:
                        temp.transform.localScale = Vector3.one * masterScale;
                        break;
                }

                temp.CardChange(i);

                temp.name = "card " + (i + 1) + " " + (j + 1);
            }
        }
    }

    public void suffleCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randNum = Random.Range(0, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randNum];
            cards[randNum] = temp;
            Debug.Log(temp.transform.localScale);
        }
    }

    public void getCard(Card card)
    {
        if (curCard1 == null)
        {
            curCard1 = card;
            card.Flip(true);
        }
        else if (curCard2 == null)
        {
            curCard2 = card;
            card.Flip(true);

            if (curCard1.Idx == curCard2.Idx)
            {
                StartCoroutine(CO_TwoCardSame());
            }
            else
            {
                StartCoroutine(CO_TwoCardDiff());

            }
        }
    }

    WaitForSeconds waitForCard = new WaitForSeconds(1.0f);
    IEnumerator CO_TwoCardSame()
    {
        Card card1 = curCard1;
        Card card2 = curCard2;

        cards.Remove(curCard1);
        cards.Remove(curCard2);

        curCard1 = null;
        curCard2 = null;

        bool isStageEnd = cards.Count == 0;

        yield return waitForCard;
        SoundManager.Inst.PlaySFX("CorrectSound");

        //여기서 대신 연출

        StartCoroutine(CO_DestroyCard(card1, card2));


        if (isStageEnd)
        {
            yield return new WaitForSeconds(1.0f);
            resetStage();
        }
    }

    IEnumerator CO_DestroyCard(Card card1, Card card2)
    {
        card1.anim.SetTrigger("GetBig");
        card1.mover.Move_Time(board.disappearTransform.position, 0.5f);
        card2.anim.SetTrigger("GetBig");
        card2.mover.Move_Time(board.disappearTransform.position, 0.5f);

        yield return new WaitForSeconds(0.5f);

        card1.mover.Move_Time(board.disappearTransform.position + Vector3.up * 1.5f, 1.0f);
        card2.mover.Move_Time(board.disappearTransform.position + Vector3.up * 1.5f, 1.0f);

        yield return new WaitForSeconds(1.0f);


        Destroy(card1.gameObject);
        Destroy(card2.gameObject);


    }
    IEnumerator CO_TwoCardDiff()
    {
        Card card1 = curCard1;
        Card card2 = curCard2;

        curCard1 = null;
        curCard2 = null;

        yield return waitForCard;
        SoundManager.Inst.PlaySFX("WrongSound");


        card1.Flip(false);
        card2.Flip(false);
    }

    /// <summary>
    /// 카드 전체를 뒤집는 함수 true일 때 앞면 false일 때 뒷면
    /// </summary>
    /// <param name="isFront"></param>
    public void allChangeCard(bool isFront)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Flip(isFront);
        }
    }

    #endregion Card Logic

    public void EndApplication()
    {
        GameManager.Inst.EndApplication();
    }

}
