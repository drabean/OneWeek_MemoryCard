using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, Object_Interactable
{
    // ī�带 ��Ÿ���� �ε���
    public int Idx;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.rotation.y == 180)
        {

        }
    }

    public void Interact()
    {
        this.gameObject.transform.Rotate(0, 30f, 0);
    }

    
}
