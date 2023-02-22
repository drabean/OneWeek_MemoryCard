using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    int touchCount = 0;
    [SerializeField] GameObject relicsCardPrefab;
    SpriteRenderer sp;
    Color curColor;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        curColor = sp.color;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            touchCount++;
            switch (touchCount)
            {
                case 1:
                    {
                        SoundManager.Inst.PlaySFX("SFX_Soil1");
                        sp.color = new Color(curColor.r, curColor.g, curColor.b, 0.9f);
                    }
                    break;
                case 2:
                    {
                        SoundManager.Inst.PlaySFX("SFX_Soil2");
                        sp.color = new Color(curColor.r, curColor.g, curColor.b, 0.5f);
                    }
                    break;
                case 3:
                    {
                        SoundManager.Inst.PlaySFX("SFX_Soil3");
                        ReadySceneManager.Inst.objectsList.Add(Instantiate(relicsCardPrefab, transform.position, Quaternion.identity));
                        ReadySceneManager.Inst.objectsList.Remove(gameObject);
                        ReadySceneManager.Inst.removeDustCount++;
                        Destroy(gameObject);
                    }
                    break;
            }
            if (ReadySceneManager.Inst.removeDustCount == 10)
            {
                ReadySceneManager.Inst.ChangeGuideTextImage();
                ReadySceneManager.Inst.removeDustCount = 0;
            }
        }
    }

}
