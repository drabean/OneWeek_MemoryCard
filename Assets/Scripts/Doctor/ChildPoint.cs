using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPoint : MonoBehaviour, Object_Interactable
{
    Object_Move move;
    [SerializeField] Note note;
    float speed = 10;
    private void Awake()
    {
        move = GetComponent<Object_Move>();
        note = FindObjectOfType<Note>();
    }

    public void Interact()
    {
        Debug.Log("클릭했다");
        move.Move_Speed(note.transform.position, speed);
    }
}
