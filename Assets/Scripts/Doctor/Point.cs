using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    bool isLight = false;
    bool isWait = false;
    Coroutine LightCo = null;
    SpriteRenderer sp;
    [SerializeField] TextMeshProUGUI textPrefab;
    TextMeshProUGUI waitingTimeText;
    float waitTime;
    Camera camera;
    [SerializeField] GameObject[] childPoint;
    
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        camera = Camera.main;
    }

    private void Update()
    {
        if (isWait == true)
        {
            waitTime -= Time.deltaTime;
            waitingTimeText.text = waitTime.ToString("N0");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLight == false && collision.tag == "Point")
        {
            LightCo = StartCoroutine(nameof(CO_Examination));
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLight == false && collision.tag == "Point")
        {
            StopCoroutine(LightCo);
            sp.enabled = false;
            DictionaryPool.Inst.Destroy(waitingTimeText.gameObject);
            isWait = false;
        }
    }

    /// <summary>
    /// 3�ʵ��� �����Ǹ� ������ ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_Examination()
    {
        sp.enabled = true;
        waitingTimeText = DictionaryPool.Inst.Instantiate(textPrefab.gameObject, camera.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<TextMeshProUGUI>();
        isWait = true;
        waitTime = 2;
        yield return new WaitForSeconds(2f);
        isLight = true;
        DictionaryPool.Inst.Destroy(waitingTimeText.gameObject);
        isWait = false;
        
        // ���⿡ ������ �� ����
        sp.color = Color.yellow;
        for (int i = 0; i < childPoint.Length; i++)
        {
            childPoint[i].SetActive(true);
        }
    }

}
