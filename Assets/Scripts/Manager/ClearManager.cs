using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : Singleton<ClearManager>
{
    public Transform[] location;
    public GameObject[] cardObject; // ī�� �� ������Ʈ
    public Transform finalPos;  // ������ ���������� �־���ϴ� ��ġ
    public GameObject board; // ������Ʈ���� ����ִ� ����
    public GameObject parentPos; // �θ�ü�� ���� ��ġ
    public GameObject fadeOut; // ȭ���� �˰� ����� ������Ʈ
    public GameObject stamp;  // ���� ����Ʈ
    List<int> idxList = new List<int>(); // ���� 3���� �����ϱ� ���� �ε����� ������ �ִ� ����Ʈ
    List<int> remainList = new List<int>(); // �����ִ� �ε��� ����Ʈ
    List<GameObject> objectList = new List<GameObject>(); // 
    bool isClick = false;
    void Start()
    {
        if (GameDatas.Inst.theme == THEME.POLICE)
        {
            StartCoroutine(CO_Arrest());
        }
        else
        {
            // ������� �׸� �� �� Ŭ���� �� ����
            SelectRandomNum();
            // 
            for (int i = 0; i < 3; i++)
            {
                GameObject temp = Instantiate(cardObject[idxList[i]], location[i].position, Quaternion.identity, board.transform);
                temp.SetActive(true);
                temp.transform.localScale *= 2.25f;
                objectList.Add(temp);
            }
        }
    }

    IEnumerator CO_Arrest()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(stamp, GameObject.Find("Canvas").transform);
        StartCoroutine(CO_GameOver());

    }
    /// <summary>
    /// �ߺ����� �ʴ� ���� ���� 3�� �������� �Լ�
    /// </summary>
    void SelectRandomNum()
    {
        for (int i = 0; i < cardObject.Length; i++)
        {
            remainList.Add(i);
        }
        for (int i = 0; i < 3; i++)
        {
            int curRandom = Random.Range(0,remainList.Count);
            if (idxList.Contains(curRandom))
            {
                curRandom = Random.Range(0, cardObject.Length);
                i--;
            }
            else
            {
                idxList.Add(curRandom);
                remainList.Remove(curRandom);
                Debug.Log(curRandom);
            }
        }
    }
    /// <summary>
    /// ���尡 �Ʒ��� �������� ���� ��������� �Ѿ�� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    public void ClickObject(GameObject obj)
    {
        if (!isClick)
        {
            board.GetComponent<Object_Move>().Move_Time(new Vector3(0, -6, 0), 1.5f);
            fadeOut.SetActive(true);
            Instantiate(stamp,GameObject.Find("Canvas").transform);
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

    public void Btn_GameOver()
    {
        if (!isClick)
        {
            fadeOut.SetActive(true);
            Instantiate(stamp, GameObject.Find("Canvas").transform);
            StartCoroutine(CO_GameOver());
            isClick = true;
        }
    }
}
