using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Move : MonoBehaviour
{
    //���� �����Ϸ��� ������Ʈ��, ������ ��ũ��Ʈ�� �޷��ִ� ������Ʈ�� �ٸ��ٸ� moveTr�� ������ ������Ʈ transform ������ �˴ϴ�
    public Transform moveTr;

    Coroutine curMoveCO;

    private void Awake()
    {
        moveTr = transform;
    }
    public bool isMoving => curMoveCO != null;

    /// <summary>
    /// �������� �ӵ��� �޾�, �� �ӵ��� �������� �̵�.
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
    /// �������� �̵��ð��� �޾�, �̵��ð��� ���� �������� �̵�.
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