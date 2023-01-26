using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private float maxDistance = 15f;

    public Object_Interactive[] objs = new Object_Interactive[10];

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            pos = pos.x * Vector3.right + pos.y * Vector3.up;

            switch (Input.touches[i].phase)
            {
                case TouchPhase.Began:
                    {
                        RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, maxDistance);

                        if (hit.collider != null)
                        {
                            if (hit.transform.TryGetComponent<Object_Interactive>(out Object_Interactive obj))
                            {
                                objs[i] = obj;
                                obj.onTouchDown(pos);
                            }
                            else
                            {
                                objs[i] = null;
                            }
                        }

                    }
                    break;

                case TouchPhase.Ended:
                    if (objs[i] != null)
                    {
                        objs[i].onTouchUp(pos);
                        objs[i] = null;
                    }
                    break;

                default:
                    if (objs[i] != null)
                    {
                        objs[i].onTouchDrag(pos);
                    }
                    break;
            }
        }
    }
}