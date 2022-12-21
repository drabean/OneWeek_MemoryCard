using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Camera cam;

    float maxDistance = 15f;
    Vector3 mousePosition;
    int layerMask;


    private void Start()
    {
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance, layerMask);
            //Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);

            if (hit)
            {
                if (hit.transform.TryGetComponent<Object_Interactable>(out Object_Interactable obj))
                {
                    obj.Interact();
                }

            }
        }
    }
}
