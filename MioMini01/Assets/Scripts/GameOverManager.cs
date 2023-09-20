using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GameOverManager : MonoBehaviour, IPointerClickHandler
{
    //top view
    public TextMeshProUGUI txt_lv;
    public Image img_expbar;
    public TextMeshProUGUI txt_money;

    //top view event
    float smoothSpeed = 10f;
    float smoothValue;
    float expScore;
    float[] maxExp = {100,120,130,140,150,160,170,180,190,200};
    bool isScoreCheck = false;
    bool isExtraExp = false;

    float coinScore;
    bool isCoinCheck = false;
    

    int lv = 0;

    //second view
    public Image img_player;
    public TextMeshProUGUI txt_player;
    public Image img_mio;
    public TextMeshProUGUI txt_mio;
    int cnt;
    int cnt2;
    int cnt3;
    int cnt4;
    //third view
    public TextMeshProUGUI txt_score;

    //thrid view event


    //bottom view
    Button btn_quit;
    Button btn_restart;
    public TextMeshProUGUI txt_token;
    Button btn_token;


    public void GameOver()
    {
        if (isScoreCheck == false)
        {
            //경험치 계산
            expScore = MiniGameManager.Instance.Score;

            /*if(maxExp[GameManager.Instance.Level] < expScore)
            {
                extraExp = expScore - maxExp[GameManager.Instance.Level];
            }*/
            if (maxExp[0] < expScore)
            {
                //extraExp = expScore - maxExp[0];
                isExtraExp = true;
            }
            else
            {
                isExtraExp = false;
            }
            /*if (maxExp[0] < GameManager.Instance.Exp + expScore)
            {
                //extraExp = expScore - maxExp[0];
                isExtraExp = true;
            }
            else
            {
                isExtraExp = false;
            }*/

            //경험치 증가
            StartCoroutine(ExpEvent());

            //재화 증가
            coinScore += 1000;
            StartCoroutine(CoinEvent());

            //프로필 표시
            /*img_player.sprite = 수정
            txt_player.text = GameManager.Instance.PlayerName;*/

            //제일 많이 먹은 미오 표시
            for(int i = 0; i<MiniGameManager.Instance.LotMio.Length; i++)
            {
                
                if(MiniGameManager.Instance.LotMio[i].ToString().IndexOf("01") > 0)
                {
                    cnt++;
                }
                if (MiniGameManager.Instance.LotMio[i].ToString().IndexOf("02") > 0)
                {
                    cnt2++;
                }
                if (MiniGameManager.Instance.LotMio[i].ToString().IndexOf("03") > 0)
                {
                    cnt3++;
                }
                if (MiniGameManager.Instance.LotMio[i].ToString().IndexOf("04") > 0)
                {
                    cnt4++;
                }
            }
            if(cnt > cnt2 && cnt > cnt3 && cnt>cnt4)
            {
                img_mio.sprite = this.GetComponent<HariManager>().mioSprite[0];
            }
            else if(cnt2 > cnt && cnt2 > cnt3 && cnt2 > cnt4)
            {
                img_mio.sprite = this.GetComponent<HariManager>().mioSprite[1];
            }
            else if(cnt3 > cnt && cnt3 > cnt2 && cnt3 > cnt4)
            {
                img_mio.sprite = this.GetComponent<HariManager>().mioSprite[2];
            }
            else if(cnt4 > cnt && cnt4 > cnt2 && cnt4 > cnt3)
            {
                img_mio.sprite = this.GetComponent<HariManager>().mioSprite[3];
            }

            //점수 표시
            txt_score.text = MiniGameManager.Instance.Score.ToString();

            //남아있는 토큰 표시
            isScoreCheck = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.button);
        if(eventData.button == 0)
        {
            if(!isScoreCheck)
            {
                if(expScore / maxExp[lv] > 0)
                {
                    for (int i = 0; i < (int)(expScore / maxExp[lv]); i++)
                    {
                        lv += i;
                        expScore -= maxExp[lv];
                    }

                }

                /*GameManager.Instance.Level = lv;
                GameManager.Instance.Exp = expScore;*/

                img_expbar.fillAmount = expScore / maxExp[lv];

                txt_lv.text = lv.ToString();
                txt_money.text = coinScore.ToString();

                isScoreCheck = true;
            }
        }
    }

    public void QuitGame()
    {

    }

    public void AddTokenEvent()
    {

    }

    public void TokenView()
    {
        txt_token.text =
                MiniGameManager.Instance.Tokken.ToString() + " / " + MiniGameManager.Instance.MaxTokken.ToString();
    }

    //경험치 증가 및 경험치에 따른 레벨 변화
    IEnumerator ExpEvent()
    {
        if (isExtraExp)
        {
            for (int i = 0; i < (int)(expScore / maxExp[lv]); i++)
            {
                while (img_expbar.fillAmount < 1)
                {
                    smoothValue = Mathf.Lerp(img_expbar.fillAmount, 1.01f, Time.deltaTime * smoothSpeed);
                    img_expbar.fillAmount = smoothValue;
                    yield return new WaitForSeconds(0.01f);
                }
                expScore = expScore - maxExp[lv];
                img_expbar.fillAmount = 0;
                lv++;
                txt_lv.text = lv.ToString();
            }

            isExtraExp = false;
        }

        while (img_expbar.fillAmount < expScore / maxExp[lv])
        {
            smoothValue = Mathf.Lerp(img_expbar.fillAmount,  expScore / maxExp[lv], 
                Time.deltaTime * smoothSpeed);
            img_expbar.fillAmount = smoothValue;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.01f);
    }

    /*IEnumerator ExpEvent()
    {
        if (isExtraExp)
        {
            for (int i = 0; i < (int)((GameManager.Instance.Exp + expScore) / maxExp[lv]); i++)
            {
                while (img_expbar.fillAmount < 1)
                {
                    smoothValue = Mathf.Lerp(img_expbar.fillAmount, 1.01f, Time.deltaTime * smoothSpeed);
                    img_expbar.fillAmount = smoothValue;
                    yield return new WaitForSeconds(0.01f);
                }
                expScore = GameManager.Instance.Exp + expScore - maxExp[lv];
                img_expbar.fillAmount = 0;
                lv++;
                txt_lv.text = lv.ToString();
            }

            isExtraExp = false;
        }

        while (img_expbar.fillAmount < (GameManager.Instance.Exp + expScore) / maxExp[lv])
        {
            smoothValue = Mathf.Lerp(img_expbar.fillAmount, (GameManager.Instance.Exp + expScore) / maxExp[lv],
                Time.deltaTime * smoothSpeed);
            img_expbar.fillAmount = smoothValue;
            yield return new WaitForSeconds(0.01f);
        }

        GameManager.Instance.Level = lv;
        GameManager.Instance.Exp = expScore;

        yield return new WaitForSeconds(0.01f);
    }*/

    IEnumerator CoinEvent()
    {
        //coinScore = MiniGameManager.Instance.Score / 10;
        
        for (int i = 0; i<=coinScore; i++)
        {
            txt_money.text = i.ToString();
            //txt_money.text = (GameManager.Instance.MinigameCoin + i).ToString();

            if (coinScore > 100)
            {
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                yield return new WaitForSeconds(0.005f);
            }
            
        }


        yield return null;
    }
}
