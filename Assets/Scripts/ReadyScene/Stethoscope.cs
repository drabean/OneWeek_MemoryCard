using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour, Object_Interactive
{
    public Transform targetTr;
    public GameObject lightObject;
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, targetTr.position);
        if (distance < 1) lightObject.transform.localScale = Vector3.one * 5;
        else lightObject.transform.localScale = Vector3.one * (5/(distance));


    }
    public void onTouchDown(Vector3 touchPos)
    {

    }
    public void onTouchDrag(Vector3 touchPos)
    {
        transform.position = touchPos;
    }
    public void onTouchUp(Vector3 touchPos)
    {

    }
    
    
}
