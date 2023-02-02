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
    /// Ŭ�� ���� �� bool���� ���� �޴� On/Off
    /// </summary>
    public void Click_Button()
    {
        if (isMenu == false) MenuOn();
        else MenuOff();
    }

    /// <summary>
    /// �޴��� ���ִ� �Լ�
    /// </summary>
    void MenuOn()
    {
        exitBtn.gameObject.SetActive(true);
        undoBtn.gameObject.SetActive(true);
        isMenu = true;
    }

    /// <summary>
    /// �޴��� ���ִ� �Լ�
    /// </summary>
    void MenuOff()
    {
        exitBtn.gameObject.SetActive(false);
        undoBtn.gameObject.SetActive(false);
        isMenu = false;
    }

}
