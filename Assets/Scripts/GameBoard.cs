using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject[] CardPositions;
    public GameObject[] Fires;

    public GameObject dummyCard;
    
    public void setCardsPosition(List<Card> cards)
    {
        if (dummyCard != null) Destroy(dummyCard);

        for(int i = 0; i < CardPositions.Length; i++)
        {
            cards[i].transform.position = CardPositions[i].transform.position;
        }
    }

    public void setFire(float count)
    {
        Debug.Log(count * Fires.Length);
        int FireNum = (int) (count * Fires.Length);
        Debug.Log("FIRENUM:" + FireNum);
        for (int i = 0; i < FireNum; i++)
        {
            Fires[i].SetActive(true);
        }
        for(int i = FireNum; i < Fires.Length; i++)
        {
            Fires[i].SetActive(false);
        }
    }
}
