using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour, Object_Interactive
{
    Vector3 mOffset = new Vector3(-1, 1, 0);
    public void onTouchDown(Vector3 touchPos)
    {

    }
    public void onTouchDrag(Vector3 touchPos)
    {
        transform.position = touchPos + mOffset;
    }
    public void onTouchUp(Vector3 touchPos)
    {

    }
    
}
