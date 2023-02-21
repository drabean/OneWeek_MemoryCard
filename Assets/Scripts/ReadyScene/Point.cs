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
    Camera cam;
    [SerializeField] GameObject[] doctorObject;
    [SerializeField] GameObject stethoscope;
    [SerializeField] GameObject childBody;


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        cam = Camera.main;
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
        if (isLight == false && collision.CompareTag("Point"))
        {
            LightCo = StartCoroutine(nameof(CO_Examination));
            SoundManager.Inst.PlaySFX("SFX_Stethoscope");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLight == false && collision.CompareTag("Point"))
        {
            StopCoroutine(LightCo);
            Destroy(waitingTimeText.gameObject);
            isWait = false;
        }
    }

    /// <summary>
    /// 3�ʵ��� �����Ǹ� ������ ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_Examination()
    {
        waitingTimeText = Instantiate(textPrefab.gameObject, cam.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<TextMeshProUGUI>();
        isWait = true;
        waitTime = 2;
        yield return new WaitForSeconds(2f);
        isLight = true;
        ReadySceneManager.Inst.ChangeGuideTextImage();
        Destroy(waitingTimeText.gameObject);
        stethoscope.SetActive(false);
        childBody.SetActive(false);
        isWait = false;
        
        // ���⿡ ������ �� ����
        sp.color = Color.yellow;

        for (int i = 0; i < doctorObject.Length; i++)
        {
            doctorObject[i].SetActive(true);
        }
    }

}
