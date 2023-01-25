using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject[] CardPositions;
    public GameObject dummyCard;
    public Transform disappearTransform;
    
    public void setCardsPosition(List<Card> cards)
    {
        if (dummyCard != null) Destroy(dummyCard);
        Debug.Log(CardPositions.Length);
        for(int i = 0; i < CardPositions.Length; i++)
        {
            cards[i].transform.position = CardPositions[i].transform.position;
        }
    }

}
