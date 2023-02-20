using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : Singleton<ClearManager>
{
    public Transform[] location;
    public GameObject[] cardObject; // 카드 내 오브젝트
    public Transform finalPos;  // 유물이 마지막으로 있어야하는 위치
    public GameObject board; // 오브젝트들을 담고있는 보드
    public GameObject parentPos; // 부모객체로 만들 위치
    public GameObject fadeOut; // 화면을 검게 만드는 오브젝트
    public GameObject stamp;  // 도장 이펙트
    List<int> idxList = new List<int>(); // 유물 3개를 선정하기 위한 인덱스를 가지고 있는 리스트
    List<int> remainList = new List<int>(); // 남아있는 인덱스 리스트
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
            // 고고학자 테마 일 때 클리어 씬 내용
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
    /// 중복되지 않는 랜덤 숫자 3개 가져오는 함수
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
    /// 보드가 아래로 내려가고 게임 종료씬으로 넘어가는 함수
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
