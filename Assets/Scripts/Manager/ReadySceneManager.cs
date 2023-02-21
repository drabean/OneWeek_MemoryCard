using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ReadySceneManager : Singleton<ReadySceneManager>
{
    public List<GameObject> objectsList = new List<GameObject>();
    public int removeDustCount;
    public Transform NotePos;
    public GameObject firstTextImage;
    public GameObject secondTextImage;

    private void Start()
    {
        switch (GameDatas.Inst.theme)
        {
            case THEME.POLICE:
                SoundManager.Inst.PlayBGM("BGM_Police");
                break;
            case THEME.ARCHAEOLOGIST:
                SoundManager.Inst.PlayBGM("BGM_Archaeologist");
                break;
            case THEME.DOCTOR:
                SoundManager.Inst.PlayBGM("BGM_Doctor");
                break;
        }
    }

    /// <summary>
    /// 특정 오브젝트를 클릭해서 노트로 움직이게 만들떄 불리는 함수.
    /// </summary>
    public void ClickObject(GameObject obj)
    {
        objectsList.Remove(obj);
        StartCoroutine(CO_RemoveObject());
        if (objectsList.Count == 0) GameOver();
    }

    public void GameOver()
    {
        StartCoroutine(CO_GameOver());
    }
    IEnumerator CO_GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        SoundManager.Inst.StopBGM();
        GameDatas.Inst.scene = SCENE.GAME;
        SceneManager.LoadScene("3.GameScene");
    }
    IEnumerator CO_RemoveObject()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.Inst.PlaySFX("SFX_LightDestroy");
    }
    public void ChangeGuideTextImage()
    {
        firstTextImage.SetActive(false);
        secondTextImage.SetActive(true);
    }

    
}
