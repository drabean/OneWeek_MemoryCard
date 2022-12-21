using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, Object_Interactable
{
    // 카드를 나타내는 인덱스
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
