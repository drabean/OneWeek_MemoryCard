using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject[] CardPositions;

    
    public void setCardsPosition(List<Card> cards)
    {
        for(int i = 0; i < CardPositions.Length; i++)
        {
            cards[i].transform.position = CardPositions[i].transform.position;
        }
    }
}
