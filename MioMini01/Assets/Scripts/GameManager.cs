using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //���� ����
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
        Instance = this; //���� �ʱ�ȭ
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

