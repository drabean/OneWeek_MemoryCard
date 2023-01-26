using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Camera cam;
    private float maxDistance = 15f;
    private Vector3 mousePos;
    private int layerMask;


    private void Start()
    {
        maxDistance = float.MaxValue; // Raycast의 distance를 최대로 설정
        cam = Camera.main; // ray를 쏠 카메라를 설정
        layerMask = 1 << LayerMask.NameToLayer("Interactable"); // Layer의 이름이 Interactable인 오브젝트
    }
    private void Update()
    {
        // 터치가 10개까지 따로 설정 가능하게 설정
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {

                    mousePos = cam.ScreenToWorldPoint(touch.position);

                    RaycastHit2D[] hit = new RaycastHit2D[10];

                    hit[i] = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);
                    Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

                    if (hit[i].collider != null)
                    {
                        Debug.Log(hit[i].transform.name);

                        if (hit[i].transform.TryGetComponent<Object_Interactable>(out Object_Interactable obj))
                        {
                            obj.Interact();
                        }
                    }
                }
            }
        }
    }
}