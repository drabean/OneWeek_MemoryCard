using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour, Object_Interactive
{
    // ī�带 ��Ÿ���� �ε���
    public int Idx;
    public Sprite[] frontsprites;
    public Sprite backSprite;
    public float scaleX;
    public float scaleY;
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
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }
    public void Flip(bool isFront)
    {
        SoundManager.Inst.PlaySFX("SFX_CardFlip");

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


    public void onTouchDown(Vector3 touchPos)
    {
        if (isFront) return;
        CardManager.Inst.getCard(this);
    }

    public void onTouchDrag(Vector3 touchPos)
    {
    }

    public void onTouchUp(Vector3 touchPos)
    {
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

    public void changeLayer()
    {
        sp.sortingLayerName = "FrontFloor";
    }

    #endregion
}
