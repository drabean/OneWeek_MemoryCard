using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst;

    public GameObject CardPrefab;
    public GameObject[] BoardPrefabs;

    public List<Card> cards;

    int difficulty;

    GameBoard board;

    public Card curCard1;
    public Card curCard2;

    int stageCount;

    private void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        switch (GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.EASY:
                difficulty = 6;
                board = Instantiate(BoardPrefabs[1], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                break;
            case DIFFICULTY.NORMAL:
                board = Instantiate(BoardPrefabs[2], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 8;
                break;
            case DIFFICULTY.HARD:
                board = Instantiate(BoardPrefabs[3], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 10;
                break;
            case DIFFICULTY.MASTER:
                board = Instantiate(BoardPrefabs[4], Vector3.zero, Quaternion.identity).GetComponent<GameBoard>();
                difficulty = 12;
                break;
        }
        stageCount = 4;

        resetStage();
    }
    #region Stage

    public void resetStage()
    {
        stageCount--;
        if (stageCount < 0) GameManager.Inst.GameEnd();
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


        //여기서 카드 다 뒤집고 보여주기
        yield return new WaitForSeconds(5.0f);
        //여기서 카드 다시 다 뒤집고 게임 시작하기.

    }

    #endregion Stage

    #region Card Logic
    public void generateCard()
    {
        for (int i = 0; i < difficulty / 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Card temp = Instantiate(CardPrefab).GetComponent<Card>();

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
        yield return waitForCard;

        Destroy(curCard1.gameObject);
        Destroy(curCard2.gameObject);
        curCard1 = null;
        curCard2 = null;



        if (cards.Count == 2)
        {
            yield return new WaitForSeconds(1.0f);
            resetStage();
        }
    }

    IEnumerator CO_TwoCardDiff()
    {
        yield return waitForCard;

        curCard1.Flip(false);
        curCard2.Flip(false);
        curCard1 = null;
        curCard2 = null;
    }
    #endregion Card Logic
}
