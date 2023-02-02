using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] Collider2D col;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            col.enabled = true;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            col.enabled = false;
        }
    }
}
