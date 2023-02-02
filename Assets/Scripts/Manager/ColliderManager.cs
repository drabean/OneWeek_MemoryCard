using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private float maxDistance = 15f;
    GameObject collider = null;
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

                        collider = new GameObject("Coll");
                        CircleCollider2D cc = collider.AddComponent<CircleCollider2D>();
                        collider.transform.position = pos;
                        collider.tag = "Interactable";
                        Rigidbody2D rb = collider.AddComponent<Rigidbody2D>();
                        rb.gravityScale = 0;
                        
                    }
                    break;

                case TouchPhase.Ended:
                    Destroy(collider);
                    break;
                default:
                    collider.transform.position = pos;
                    break;
            }
        }
    }


}
