using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [SerializeField] private string PlayerName;
    [SerializeField] private int Level;
    [SerializeField] private float Exp;
    [SerializeField] private float Score;

    [SerializeField] private Vector3 lastPosition;

    //»ý¼ºÀÚ
    public SaveData(string t_PlayerName, int t_Level, float t_Exp, float t_Score, Vector3 t_lastPosition)
    {
        PlayerName = t_PlayerName;
        Level = t_Level;
        Exp = t_Exp;
        Score = t_Score;

        lastPosition = new Vector3(t_lastPosition.x, t_lastPosition.y, t_lastPosition.z);
    }
}
