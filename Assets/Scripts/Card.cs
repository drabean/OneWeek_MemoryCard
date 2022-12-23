using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour, Object_Interactable
{
    // 카드를 나타내는 인덱스
    public int Idx;
    public Sprite[] frontsprites;
    public Sprite backSprite;

    public bool isFront;


    Sprite curFrontSprite;
    Sprite curBackSprite;
    public Animator anim;
    SpriteRenderer sp;

    public Object_Move mover;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        mover = GetComponent<Object_Move>();
    }

    public void Interact()
    {
        if (isFront) return;
        CardManager.Inst.getCard(this);
    }

    public void Flip(bool isFront)
    {
        SoundManager.Inst.PlaySFX("FlipSound");
        if (isFront)
        {
            this.isFront = true;
            anim.SetTrigger("FlipFront");
        }
        else
        {
            anim.SetTrigger("FlipBack");
        }
    }

    public void setIsFrontFalse()
    {
        isFront = false;
    }


    public void CardChange(int idx)
    {
        CardManager.Inst.cards.Add(this);
        this.Idx = idx;
        curFrontSprite = frontsprites[idx];
        curBackSprite = backSprite;
    }

    #region 애니메이터 호출 함수
    public void showFront()
    {
        sp.sprite = curFrontSprite;
    }
    public void showBack()
    {
        sp.sprite = curBackSprite;
    }

    public void changeLayer()
    {
        sp.sortingLayerName = "FrontFloor";
    }
    #endregion
}
