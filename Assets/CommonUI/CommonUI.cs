using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommonUI : MonoBehaviour
{
    //MinigameTown의 PackageName
    public string TownPackageName = "com.DefaultCompany.MinigameTownTest";


    public GameObject UIPanel;

    bool SFXOn = true;
    bool BGMOn = true;

    [SerializeField] Sprite[] TogleImages;
    [SerializeField] Image Image_BGM;
    [SerializeField] Image Image_SFX;


    public static CommonUI Inst;


    public GameObject Group_Setting;
    public GameObject Group_Town;

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += ChangeBtnStatus;
            SceneManager.sceneLoaded += ChangeSceneStatus;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    /// <summary>
    /// 현재 씬에 대한 정보를 전달해주는 함수
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void ChangeSceneStatus(Scene scene, LoadSceneMode mode)
    {
        switch(scene.name)
        {
            case "2.ArchaeologistReadyScene":
            case "2.DoctorReadyScene":
            case "2.PoliceReadyScene":
                GameDatas.Inst.scene = SCENE.READY;
                break;
            case "3.GameScene":
                GameDatas.Inst.scene = SCENE.GAME;
                break;
            case "4.ArchaeologistClearScene":
            case "4.DoctorClearScene":
            case "4.PoliceClearScene":
                GameDatas.Inst.scene = SCENE.CLEAR;
                break;
            case "Additive_EndScene":
                GameDatas.Inst.scene = SCENE.END;
                break;
        }
    }

    /// <summary>
    /// 해당 함수 switch문에서 Scene 이름 넣어주시면 됩니다.
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void ChangeBtnStatus(Scene scene, LoadSceneMode mode)
    {
        switch(scene.name)
        {
            //UI가 필요없는 씬 (난이도 선택 씬 등)
            
            case "Additive_EndScene":
            case "1.SelectModeScene":
                Group_Town.SetActive(false);
                Group_Setting.SetActive(false);
                break;

            //마을로 가는 버튼 필요한 씬(타입 선택 씬 등)
            case "0.StartScene":
                Group_Town.SetActive(true);
                Group_Setting.SetActive(false);
                break;
            //팝업 버튼 필요한 씬(위에 선택 씬 외의 모든 씬)
            default:
                Group_Town.SetActive(false);
                Group_Setting.SetActive(true);
                break;
                
        }
    }
    public void Btn_Setting()
    {
        //팝업 열기
        UIPanel.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_Restart()
    {
        //restart 버튼 눌렀을때 동작은 여기에서
        Time.timeScale = 1f;
        UIPanel.SetActive(false);
        //현재 게임 타입 따라 분기가 필요
        switch(GameDatas.Inst.theme)
        {
            case THEME.POLICE:
                SceneManager.LoadScene("2.PoliceReadyScene");
                SoundManager.Inst.PlaySFX("SFX_ClickBtn");
                break;
            case THEME.ARCHAEOLOGIST:
                SceneManager.LoadScene("2.ArchaeologistReadyScene");
                SoundManager.Inst.PlaySFX("SFX_ClickBtn");
                break;
            case THEME.DOCTOR:
                SceneManager.LoadScene("2.DoctorReadyScene");
                SoundManager.Inst.PlaySFX("SFX_ClickBtn");
                break;
        }

    }

    public void Btn_Exit()
    {

        //Exit버튼 눌렀을떄 동작은 여기에서
        Time.timeScale = 1f;
        UIPanel.SetActive(false);
        SoundManager.Inst.PlayBGM("SFX_ChangeScene");
        SceneManager.LoadScene("0.StartScene");
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_Help()
    {
        Debug.Log("미?구현");
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_BGM()
    {
        if (BGMOn)
        {
            SoundManager.Inst.setBGMVolume(0);
            BGMOn = false;
            Image_BGM.sprite = TogleImages[1];
        }
        else
        {
            SoundManager.Inst.setBGMVolume(1);
            BGMOn = true;
            Image_BGM.sprite = TogleImages[0];
        }
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_SFX()
    {
        if (SFXOn)
        {
            SoundManager.Inst.setSFXVolume(0);
            SFXOn = false;
            Image_SFX.sprite = TogleImages[1];
        }
        else
        {
            SoundManager.Inst.setSFXVolume(1);
            SFXOn = true;
            Image_SFX.sprite = TogleImages[0];
        }
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_Close()
    {
        UIPanel.SetActive(false); 
        Time.timeScale = 1f;
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
    }

    public void Btn_MoveToTown()
    {
#if UNITY_ANDROID
        if (!IsAppInstalled(TownPackageName))
        {
            Debug.Log("앱이 깔려있지 않습니다");
            return;
        }
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject pm = jo.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject intent = pm.Call<AndroidJavaObject>("getLaunchIntentForPackage", TownPackageName);

        jo.Call("startActivity", intent);


        Application.Quit();
#else
        Debug.Log("NOT SUPPORTED IN EDITOR");
#endif
    }
    bool IsAppInstalled(string bundleID)
    {
#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject launchIntent = null;

        //if the app is installed, no errors. Else, doesn't get past next line
        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bundleID);
        }
        catch (System.Exception ex)
        {
            Debug.Log("exception" + ex.Message);
            //여기에서 앱이 설치 되지 않았을때의 예외처리.
        }

        return (launchIntent == null ? false : true);
#else

        Debug.LogError("NOT SUPPORTED IN EDITOR");
        return false;
#endif

    }

}
