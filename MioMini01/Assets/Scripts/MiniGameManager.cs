using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public Sprite[] H_Icon;
    public Sprite[] S_Icon;

    public TextMeshProUGUI txt_Nick;
    public float Score = 0;

    public float fiverScore = 0;
    public bool IsFiver;

    public float isCorrect;

    public float PlayTime;

    public bool GameOver;

    private void Awake()
    {
        Instance = this;
    }
}
