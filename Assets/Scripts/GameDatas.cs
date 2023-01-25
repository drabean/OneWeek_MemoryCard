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

public enum THEME
{
    POLICE,
    DOCTOR,
    ARCHAEOLOGIST
}

public class GameDatas : MonoBehaviour
{
    public static GameDatas Inst;

    public DIFFICULTY difficulty;
    public THEME theme;
    public float time;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Inst == null) Inst = this;
        else Destroy(gameObject);
    }
}
