using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour
{
    public static Adventure instance;
    public Image Img_topView;

    public Sprite[] mioSprite;
    public GameObject mioTalk;

    /*
    0 : º±≈√¡ˆ
    1 : 
     */
    public Sprite[] bgSprite;
    public TextMeshProUGUI txt_explane;
    public float currentType;


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
        this.GetComponent<StoryManager>().SelectWay(Img_topView, txt_explane, obj_choose, obj_chooseView.transform);
    }


}
