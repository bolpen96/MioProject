using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public Sprite[] H_Icon;
    public Sprite[] S_Icon;

    private void Awake()
    {
        Instance = this;
    }
}
