using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public Sprite[] H_Icon;
    public Sprite[] S_Icon;
    public Sprite[] LotMio;
    public List<Sprite> mioList;

    public int Score = 0;

    public float fiverScore = 0;
    public bool IsFiver;

    public float isCorrect;

    public float PlayTime;

    public bool GameOver;

    public int Tokken = 5;
    public int MaxTokken = 5;
    public float tokkenTime;

    private void Awake()
    {
        Instance = this;
        List<Sprite> mioList = new List<Sprite>(LotMio.ToList());
    }
}
