using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    bool isLight;
    Coroutine LightCo = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLight == false)
        {
            LightCo = StartCoroutine(nameof(CO_Examination));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLight == false)
        {
            StopCoroutine(LightCo);
        }
    }

    /// <summary>
    /// 3�ʵ��� �����Ǹ� ������ ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_Examination()
    {
        yield return new WaitForSeconds(3f);
        isLight = true;
        // ���⿡ ������ �� ����
    }

}
