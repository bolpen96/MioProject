using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public Sprite[] H_Icon;
    public Sprite[] S_Icon;

    public TextMeshProUGUI txt_Nick;
    public float Score;

    private void Awake()
    {
        Instance = this;
    }
}
