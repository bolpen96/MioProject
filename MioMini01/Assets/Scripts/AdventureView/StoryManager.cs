using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    int ranNum;
    public Sprite[] sp_bg;
    string[] str_story;
    string[,] str_choose;


    private void Start()
    {
        str_story = new string[] {"1,2,3 중 선택해야해",};
        str_choose = new string[,] { { "1", "2", "3" },{"4","5","6" } };
    }

    public void SouthStory(Image img_bg, TextMeshProUGUI txt_explane, GameObject obj_choose)
    {
        ranNum = Random.Range(0, 4);

        img_bg.sprite = sp_bg[ranNum];

    }
}
