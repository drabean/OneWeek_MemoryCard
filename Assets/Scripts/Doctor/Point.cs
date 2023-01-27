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
            DictionaryPool.Inst.Destroy(waitingTimeText.gameObject);
            isWait = false;
        }
    }

    /// <summary>
    /// 3초동안 유지되면 빛나게 만드는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_Examination()
    {
        waitingTimeText = DictionaryPool.Inst.Instantiate(textPrefab.gameObject, camera.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform).GetComponent<TextMeshProUGUI>();
        isWait = true;
        waitTime = 3;
        yield return new WaitForSeconds(3f);
        isLight = true;
        DictionaryPool.Inst.Destroy(waitingTimeText.gameObject);
        isWait = false;
        ReadyManager.Inst.doctorConfirmNum++;
        // 여기에 빛나는 것 적용
        sp.color = Color.yellow;
        if (ReadyManager.Inst.doctorConfirmNum == ReadyManager.Inst.doctorCount)
        {
            ReadyManager.Inst.GameStart();
        }
    }

}
