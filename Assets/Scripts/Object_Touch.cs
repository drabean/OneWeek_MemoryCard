using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Touch : MonoBehaviour, Object_Interactive
{
    float speed = 10;

    public void onTouchDown(Vector3 touchPos)
    {
        Debug.Log("클릭했다");
        ReadySceneManager.Inst.ClickObject(gameObject);
        GetComponent<Object_Move>().Move_Speed(ReadySceneManager.Inst.NotePos.position, speed);
    }

    public void onTouchDrag(Vector3 touchPos)
    {

    }

    public void onTouchUp(Vector3 touchPos)
    {

    }
}
