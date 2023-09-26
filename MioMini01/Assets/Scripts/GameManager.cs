using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //변수 선언
    public string PlayerName;
    public int Level;
    public float Exp;
    public float Score;
    public int MinigameCoin;

    public int State = 0;

    public int railLv;
    public float GameTime;

    public float minigameTime;

    public int Tokken = 5;
    public int MaxTokken = 5;
    public float tokkenTime;
    public float maxTokkenTime = 300;

    private void Awake()
    {
        Instance = this; //변수 초기화
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SaveManager.Load();
    }

    private void OnApplicationQuit()
    {
        SaveManager.Save();
    }

    
}

