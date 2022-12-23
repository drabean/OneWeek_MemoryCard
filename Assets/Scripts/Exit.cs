using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour, Object_Interactable
{
    public void Interact()
    {
        SceneManager.LoadScene("1.StartSCene");

    }
}
