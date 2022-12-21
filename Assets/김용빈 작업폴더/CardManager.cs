using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject CardPrefab;

    public List<GameObject> cards;

    public int difficulty = 4;

    public GameBoard board;

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
        for(int i = 0; i < cards.Count; i++)
        {
            int randNum = Random.Range(0, cards.Count);
            GameObject temp = cards[i];
            cards[i] = cards[randNum];
            cards[randNum] = temp;
        }
    }

}
