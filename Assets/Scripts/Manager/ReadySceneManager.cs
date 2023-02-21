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
    /// Ư�� ������Ʈ�� Ŭ���ؼ� ��Ʈ�� �����̰� ���鋚 �Ҹ��� �Լ�.
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
