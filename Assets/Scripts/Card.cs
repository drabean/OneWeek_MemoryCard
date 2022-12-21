using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour, Object_Interactable
{
    // 카드를 나타내는 인덱스
    public int Idx;
    public TextMeshProUGUI cardNum;
    public GameObject back;
    public Sprite[] frontSprite;

    private void Awake()
    {

    }
    void Start()
    {
        CardChange(Idx);
    }

    // Update is called once per frame
    void Update()
    {
        float rotationY = gameObject.transform.rotation.y;
        Debug.Log(gameObject.transform.rotation.y);
        if (rotationY >= 0.5f && rotationY <= 1f || rotationY <= -0.5f && rotationY >= -1f)
        {
            cardNum.gameObject.SetActive(true);
            back.SetActive(false);
        }
        else
        {
            cardNum.gameObject.SetActive(false);
            back.SetActive(true);
        }
    }

    public void Interact()
    {
        StartCoroutine(CardFlip());
    }

    IEnumerator CardFlip()
    {
        int i = 0;
        while (true)
        {
            gameObject.transform.Rotate(0, 5, 0);
            i++;
            if (i == 36) break;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }

    public void CardChange(int idx)
    {
        cardNum.text = idx.ToString();
    }

}
