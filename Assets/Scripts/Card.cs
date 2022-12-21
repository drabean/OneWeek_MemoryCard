using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour, Object_Interactable
{
    // ī�带 ��Ÿ���� �ε���
    public int Idx;
    public Sprite[] frontsprites;
    public Sprite backSprite;

    public bool isFront;


    Sprite curFrontSprite;
    Sprite curBackSprite;
    Animator anim;
    SpriteRenderer sp;


    void Awake()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void OnDestroy()
    {
        CardManager.Inst.cards.Remove(this);
    }
    public void Interact()
    {
        if (isFront) return;
        CardManager.Inst.getCard(this);
    }

    public void Flip(bool isFront)
    {
        if (isFront)
        {
            this.isFront = true;
            anim.SetTrigger("FlipFront");
        }
        else
        {
            this.isFront = false;
            anim.SetTrigger("FlipBack");

        }
    }
    public void CardChange(int idx)
    {
        CardManager.Inst.cards.Add(this);
        this.Idx = idx;
        curFrontSprite = frontsprites[idx];
        curBackSprite = backSprite;
    }

    #region �ִϸ����� ȣ�� �Լ�
    public void showFront()
    {
        sp.sprite = curFrontSprite;
    }
    public void showBack()
    {
        sp.sprite = curBackSprite;
    }
    #endregion
}
