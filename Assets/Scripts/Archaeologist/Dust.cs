using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    int touchCount = 0;
    [SerializeField] GameObject relicsCardPrefab;
    Color objColor;

    private void Awake()
    {
        objColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        
    }
    
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            touchCount++;
            Debug.Log("��Ҵ�" + touchCount);
            switch (touchCount)
            {
                case 1:
                    {
                        objColor.a = 0.9f;
                        this.gameObject.GetComponent<SpriteRenderer>().color = objColor;
                        Debug.Log("1�϶� " +objColor.a);
                    }
                    break;
                case 2:
                    {
                        objColor.a = 0.5f;
                        this.gameObject.GetComponent<SpriteRenderer>().color = objColor;
                        Debug.Log("2�϶� " + objColor.a);
                    }
                    break;
                case 3:
                    {
                        this.gameObject.SetActive(false);
                        DictionaryPool.Inst.Instantiate(relicsCardPrefab, this.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
                    }
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            Debug.Log("��Ҵ�" + touchCount);
            touchCount++;
        }
    }

}
