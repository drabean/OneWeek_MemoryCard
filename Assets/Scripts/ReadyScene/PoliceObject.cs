using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceObject : MonoBehaviour, Object_Interactable
{
    Object_Move move;
    [SerializeField] Note note;
    [SerializeField] float speed = 30;
    private void Awake()
    {
        move = GetComponent<Object_Move>();
        note = FindObjectOfType<Note>();
    }
    
    public void Interact()
    {
        Debug.Log("Ŭ���ߴ�");
        move.Move_Speed(note.transform.position, speed);
    }
}
