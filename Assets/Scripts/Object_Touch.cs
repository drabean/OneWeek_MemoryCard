using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object_Touch : MonoBehaviour, Object_Interactive
{
    float speed = 10;
    Object_Move move = null;
    
    private void Awake()
    {
        move = GetComponent<Object_Move>();
    }
    public void onTouchDown(Vector3 touchPos)
    {
        Debug.Log("클릭했다");
        switch (GameDatas.Inst.scene)
        {
            case SCENE.READY:
                ReadySceneManager.Inst.ClickObject(gameObject);
                move.Move_Speed(ReadySceneManager.Inst.NotePos.position, speed);
                break;
            case SCENE.CLEAR:
                switch (GameDatas.Inst.theme)
                {
                    case THEME.ARCHAEOLOGIST:
                        gameObject.transform.localScale = gameObject.transform.localScale * 2;
                        move.Move_Speed(ClearManager.Inst.finalPos.position, speed);
                        break;
                    case THEME.DOCTOR:
                        gameObject.transform.SetParent(ClearManager.Inst.parentPos.transform);
                        gameObject.transform.position = ClearManager.Inst.finalPos.position;
                        break;
                }
                ClearManager.Inst.ClickObject(gameObject);
                SoundManager.Inst.PlaySFX("SFX_Clear");
                break;
        }
    }

    public void onTouchDrag(Vector3 touchPos)
    {

    }

    public void onTouchUp(Vector3 touchPos)
    {

    }
}
