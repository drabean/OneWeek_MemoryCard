using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Move : MonoBehaviour
{
    //만약 움직일려는 오브젝트와, 실제로 스크립트가 달려있는 오브젝트가 다르다면 moveTr에 움직일 오브젝트 transform 넣으면 됩니다
    public Transform moveTr;

    Coroutine curMoveCO;

    private void Awake()
    {
        moveTr = transform;
    }
    public bool isMoving => curMoveCO != null;

    /// <summary>
    /// 목적지와 속도를 받아, 그 속도로 목적지로 이동.
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="speed"></param>
    public void Move_Speed(Vector3 destination, float speed)
    {
        if (!isMoving)
        {
            curMoveCO = StartCoroutine(CO_Move(destination, speed));
        }
        else
        {
            StopCoroutine(curMoveCO);
            curMoveCO = StartCoroutine(CO_Move(destination, speed));
        }
    }
    /// <summary>
    /// 목적지와 이동시간을 받아, 이동시간에 걸쳐 목적지로 이동.
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="time"></param>
    public void Move_Time(Vector3 destination, float time)
    {
        float speed = Vector3.Distance(destination, moveTr.position) / time;

        if (!isMoving)
        {
            curMoveCO = StartCoroutine(CO_Move(destination, speed));
        }
        else
        {
            StopCoroutine(curMoveCO);
            curMoveCO = StartCoroutine(CO_Move(destination, speed));
        }
    }


    public IEnumerator CO_Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            moveTr.position = Vector2.MoveTowards(moveTr.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
}