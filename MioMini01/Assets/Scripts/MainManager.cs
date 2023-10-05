using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

    public Image[] foods;
    public float hungryValue;
    Image Img_food;
    Image Img_upfood;
    string str_food;
    bool isFoodck = false;
    public float foodScore;

    public Image[] cleans;
    public float cleanValue;
    Image Img_clean;
    bool isCleanck = false;

    public bool isPlaying;
    public float PlayingTime;
    public int Play_result;

    public TextMeshProUGUI txt_TokenValue;
    public TextMeshProUGUI txt_tokenTime;

    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        setMioInfo();
    }

    private void Update()
    {
        //배고픔 줄어드는 이벤트
        StartCoroutine(lessHgy());

        //청결도 줄어드는 이벤트
        StartCoroutine(lessClean());

        //text UI 관련
        showTokenTxt(txt_TokenValue, txt_tokenTime);

    }

    public void setMioInfo()
    {
        for(int i = 0; i < (int)hungryValue; i++)
        {
            foods[i].fillAmount = 1;
            hungryValue--;
        }

        for(int i = 0; i<(int)cleanValue; i++)
        {
            cleans[i].fillAmount = 1;
            cleanValue--;
        }

    }

    //먹이먹이기 버튼 이벤트
    public void onClickEat()
    {
        if(Img_food.fillAmount + foodScore >= 1)
        {
            str_food = Regex.Replace(Img_food.ToString(), @"[^0-9]", "");

            Img_food.fillAmount = 1;
            Img_upfood = foods[Convert.ToInt32(str_food)];
            Img_upfood.fillAmount += foodScore;

            isFoodck = false;
        }
        else
        {
            Img_food.fillAmount += foodScore;
        }
    }

    //미니게임 진입 이벤트
    public void onMiniGame()
    {
        GameManager.Instance.State = 2;
        SceneManager.LoadScene(1);
    }

    public void showTokenTxt(TextMeshProUGUI tokenValue, TextMeshProUGUI tokenTime)
    {
        tokenValue.text = GameManager.Instance.Tokken.ToString() + " / " + GameManager.Instance.MaxTokken.ToString();
        tokenTime.text = ((int)(GameManager.Instance.tokkenTime / 60)).ToString() +
                " : " + ((int)(GameManager.Instance.tokkenTime % 60)).ToString();

        if (GameManager.Instance.Tokken != GameManager.Instance.MaxTokken)
        {
            tokenTime.gameObject.SetActive(true);
            GameManager.Instance.tokkenTime -= Time.deltaTime;

            if (GameManager.Instance.tokkenTime < 0)
            {
                GameManager.Instance.tokkenTime = GameManager.Instance.maxTokkenTime;
                GameManager.Instance.Tokken++;
            }
        }
        else
        {
            tokenTime.gameObject.SetActive(false);
        }
    }

    IEnumerator lessHgy()
    {
        if (!isFoodck)
        {
            for (int i = foods.Length - 1; i >= 0; i--)
            {
                if (foods[i].fillAmount > 0)
                {
                    Img_food = foods[i];
                    isFoodck = true;
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            if (Img_food.fillAmount > 0)
            {
                //1개당 10초
                Img_food.fillAmount -= Time.deltaTime * 0.1f;
            }
            else
            {
                isFoodck = false;
            }

        }

        yield return null;
    }

    IEnumerator lessClean()
    {
        if (!isCleanck)
        {
            for (int i = cleans.Length - 1; i >= 0; i--)
            {
                if (cleans[i].fillAmount > 0)
                {
                    Img_clean = cleans[i];
                    isCleanck = true;
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            if (Img_clean.fillAmount > 0)
            {
                //1개당 20초
                Img_clean.fillAmount -= Time.deltaTime * 0.05f;
            }
            else
            {
                isCleanck = false;
            }

        }

        yield return null;
    }

    //놀아주기 결과 값 적용 perfact:1 good:0 fail:-1
    public IEnumerator CkPlayingScore()
    {
        Debug.Log(Play_result);

        if(Play_result == 1)
        {
            cleanValue = GameManager.Instance.cleanMaxValue;
            for (int i = 0; i < (int)cleanValue; i++)
            {
                cleans[i].fillAmount = 1;
                cleanValue--;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if(Play_result == 0)
        {
            str_food = Regex.Replace(Img_clean.ToString(), @"[^0-9]", "");

            for(int i = 0; i < Convert.ToInt32(str_food)+2; i++)
            {
                cleans[i].fillAmount = 1;
                yield return new WaitForSeconds(0.1f);
            }
            isCleanck = false;
        }

        yield return null;
    }
}
