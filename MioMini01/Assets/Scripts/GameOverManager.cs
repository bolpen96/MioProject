using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
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
    float extraExp = 0;
    bool isScoreCheck = false;
    bool isExtraExp = false;
    bool expCharge = false;

    int lv = 0;

    //second view
    public Image img_player;
    public TextMeshProUGUI txt_player;
    public Image img_mio;
    public TextMeshProUGUI txt_mio;

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
            //����ġ ���
            expScore = MiniGameManager.Instance.Score;
                //MiniGameManager.Instance.Score / 10;

            /*if(maxExp[GameManager.Instance.Level] < expScore)
            {
                extraExp = expScore - maxExp[GameManager.Instance.Level];
            }*/
            if (maxExp[0] < GameManager.Instance.Exp + expScore)
            {
                //extraExp = expScore - maxExp[0];
                isExtraExp = true;
            }
            else
            {
                isExtraExp = false;
            }

            //����ġ ����
            StartCoroutine(ExpEvent());



            //��ȭ ����

            //���� ���� ���� �̿� ǥ��

            //�����ִ� ��ū ǥ��

            isScoreCheck = true;
        }
    }

    public void QuitGame()
    {

    }

    public void AddTokenEvent()
    {

    }

    //����ġ ���� �� ����ġ�� ���� ���� ��ȭ
    IEnumerator ExpEvent()
    {
        if (isExtraExp)
        {
            for (int i = 0; i < (int)((GameManager.Instance.Exp + expScore) / maxExp[lv]); i++)
            {
                Debug.Log(i);
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
    }
}
