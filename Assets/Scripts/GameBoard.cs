using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject[] CardPositions;
    public Transform disappearTransform;
    public GameObject dummyCards;
    public void setCardsPosition(List<Card> cards)
    {
        Debug.Log(CardPositions.Length);
        for(int i = 0; i < CardPositions.Length; i++)
        {
            cards[i].transform.position = CardPositions[i].transform.position;
        }
    }

    public void DestroyDummy()
    {
        dummyCards.SetActive(false);
    }
}
