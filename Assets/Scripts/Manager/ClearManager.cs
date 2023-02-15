using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : Singleton<ClearManager>
{
    public Transform[] location;
    public GameObject[] relics; // ���� ������Ʈ
    public Transform finalPos;  // ������ ���������� �־���ϴ� ��ġ
    public GameObject board; // ������ ����ִ� ����
    List<int> idxList = new List<int>(); // ���� 3���� �����ϱ� ���� �ε����� ������ �ִ� ����Ʈ
    List<GameObject> objectList = new List<GameObject>(); // 
    bool isClick = false;
    void Start()
    {
        // ������� �׸� �� �� Ŭ���� �� ����
        SelectRandomNum();
        // 
        for (int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(relics[idxList[i]], location[i].position, Quaternion.identity, board.transform);
            temp.transform.localScale *= 2.25f;
            objectList.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �ߺ����� �ʴ� ���� ���� 3�� �������� �Լ�
    /// </summary>
    void SelectRandomNum()
    {
        int curRandom = Random.Range(0,relics.Length);
        for (int i = 0; i < 3; i++)
        {
            if (idxList.Contains(curRandom))
            {
                curRandom = Random.Range(0, relics.Length);
                i--;
            }
            else
            {
                idxList.Add(curRandom);
                Debug.Log(curRandom);
            }
        }
    }

    public void ClickObject(GameObject obj)
    {
        if (!isClick)
        {
            board.GetComponent<Object_Move>().Move_Time(new Vector3(0, -6, 0), 1.5f);
            StartCoroutine(CO_GameOver());
            isClick = true;
        }
    }

    IEnumerator CO_GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        GameDatas.Inst.scene = SCENE.END;
        SceneManager.LoadScene("5.EndScenes", LoadSceneMode.Additive);
    }
}
