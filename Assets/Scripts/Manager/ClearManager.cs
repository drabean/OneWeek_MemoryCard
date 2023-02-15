using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : Singleton<ClearManager>
{
    public Transform[] location;
    public GameObject[] relics; // 유물 오브젝트
    public Transform finalPos;  // 유물이 마지막으로 있어야하는 위치
    public GameObject board; // 유물을 담고있는 보드
    List<int> idxList = new List<int>(); // 유물 3개를 선정하기 위한 인덱스를 가지고 있는 리스트
    List<GameObject> objectList = new List<GameObject>(); // 
    bool isClick = false;
    void Start()
    {
        // 고고학자 테마 일 때 클리어 씬 내용
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
    /// 중복되지 않는 랜덤 숫자 3개 가져오는 함수
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
