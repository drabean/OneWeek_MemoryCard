using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuBtn;
    [SerializeField] GameObject exitBtn;
    [SerializeField] GameObject undoBtn;
    bool isMenu;
    
    /// <summary>
    /// 클릭 했을 때 bool값에 따라 메뉴 On/Off
    /// </summary>
    public void Click_Button()
    {
        if (isMenu == false) MenuOn();
        else MenuOff();
    }

    /// <summary>
    /// 메뉴를 켜주는 함수
    /// </summary>
    void MenuOn()
    {
        exitBtn.gameObject.SetActive(true);
        undoBtn.gameObject.SetActive(true);
        isMenu = true;
    }

    /// <summary>
    /// 메뉴를 꺼주는 함수
    /// </summary>
    void MenuOff()
    {
        exitBtn.gameObject.SetActive(false);
        undoBtn.gameObject.SetActive(false);
        isMenu = false;
    }

}
