using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyManager : Singleton<ReadyManager>
{
    public int policeCount = 12;
    public int doctorCount = 4;
    public int doctorConfirmNum;
    public int ArchaeologistCount = 12;
    // Start is called before the first frame update
    void Start()
    {
        
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
