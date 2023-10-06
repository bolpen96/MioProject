using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour
{
    public static Adventure instance;
    public Image[] mioSprite;
    public GameObject mioTalk;

    public Image[] bgSprite;
    public TextMeshProUGUI txt_explane;

    public GameObject obj_chooseView;
    public GameObject obj_choose;
    
    public GameObject obj_resultView;
    public TextMeshProUGUI txt_resultExplane;
    public TextMeshProUGUI txt_resultEffect;

    public int storyNum;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        storyNum = Random.Range(0,10);
    }


}
