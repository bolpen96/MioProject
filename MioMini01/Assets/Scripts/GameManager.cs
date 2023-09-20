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

    private void Awake()
    {
        Instance = this; //변수 초기화
        DontDestroyOnLoad(gameObject);
    }

    /*var obj = FindAnyObjectByType<GameManager>();
    if(object.Length == 1)
    {
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }*/
   
}

