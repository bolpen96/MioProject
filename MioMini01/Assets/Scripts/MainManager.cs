using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public int mioLv;
    public GameObject talkObj;
    public Sprite[] emoCon;
    public Sprite[] mioTalk;


    public TextMeshProUGUI txt_hgy;
    public float maxHgy;
    public float presentHgy;

    public bool isPlaying;
    public float PlayingTime;
    public int result_zone;


    private void Awake()
    {
        instance = this;
    }

    public void onClickEat()
    {
        if(presentHgy != maxHgy)
        {
            presentHgy += 0.1f;

            txt_hgy.text = presentHgy.ToString() + " / " + maxHgy.ToString();
        }
        else
        {
            GameObject Obj_talk = Instantiate(talkObj);
            Obj_talk.transform.SetParent(transform);
        }
        
    }

    public void onMiniGame()
    {
        GameManager.Instance.State = 2;
        SceneManager.LoadScene(1);
    }
}
