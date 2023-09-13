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

    public int State = 0;

    public int railLv;
    public float GameTime;

    private void Awake()
    {
        Instance = this; //���� �ʱ�ȭ
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

