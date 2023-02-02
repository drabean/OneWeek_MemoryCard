using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadySceneManager : Singleton<ReadySceneManager>
{
    public List<GameObject> objectsList = new List<GameObject>();

    public Transform NotePos;

    /// <summary>
    /// 특정 오브젝트를 클릭해서 노트로 움직이게 만들떄 불리는 함수.
    /// </summary>
    public void ClickObject(GameObject obj)
    {
        objectsList.Remove(obj);
        if (objectsList.Count == 0) GameOver();
    }

    public void GameOver()
    {
        StartCoroutine(CO_GameOver());
    }
    IEnumerator CO_GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("3.GameScene");
    }


}
