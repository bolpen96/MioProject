using System;
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
    public float MinigameCoin;

    public int State = 0;

    public int railLv;
    public float GameTime;

    public float minigameTime;

    public int Tokken = 5;
    public int MaxTokken = 5;
    public float tokkenTime;
    public float maxTokkenTime = 300;

    public int foodMaxValue;
    public int cleanMaxValue;

    private void Awake()
    {
        Instance = this; //변수 초기화
        DontDestroyOnLoad(gameObject);
    }
    
    public T[] RemoveAt<T>(ref T[] arr, int index)
    {
        var dest = new List<T>(arr);
        dest.RemoveAt(index);
        return dest.ToArray();
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

