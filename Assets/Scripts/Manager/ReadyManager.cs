using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyManager : Singleton<ReadyManager>
{
    public int countObject;
    // Start is called before the first frame update
    void Start()
    {
        countObject = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("3.GameScene");
    }
}
