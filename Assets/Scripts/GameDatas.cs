using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DIFFICULTY
{
    EASY,
    NORMAL,
    HARD,
    MASTER
}

public class GameDatas : MonoBehaviour
{
    public static GameDatas Inst;

    public DIFFICULTY difficulty;
    public float time;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Inst = this;
    }
}
