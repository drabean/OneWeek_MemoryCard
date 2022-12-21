using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst;

    public GameObject CardPrefab;

    public List<GameObject> cards;

    public int difficulty = 4;

    public GameBoard board;

    public Card curCard1;
    public Card curCard2;

    private void Awake()
    {
        Inst = this;
    }

    private void Start()
    {
        generateCard();

        suffleCard();

        board.setCardsPosition(cards);
    }
    public void generateCard()
    {
        for (int i = 0; i < difficulty / 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject temp = Instantiate(CardPrefab);

                temp.GetComponent<Card>().Idx = i;
                temp.name = "card " + (i * 2 + j);

                cards.Add(temp);
            }
        }
    }

    public void suffleCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randNum = Random.Range(0, cards.Count);
            GameObject temp = cards[i];
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

    }

    IEnumerator CO_TwoCardDiff()
    {
        yield return waitForCard;

        curCard1.Flip(false);
        curCard2.Flip(false);
        curCard1 = null;
        curCard2 = null;
    }

}
