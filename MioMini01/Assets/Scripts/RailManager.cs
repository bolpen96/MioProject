using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RailManager : MonoBehaviour
{
    public Image rail01;
    public Image rail02;
    public Image rail03;

    public Image img_time;
    public GameObject scoreBoard;
    Color boardColor;

    public Transform targetRail01;
    public Transform targetRail02;
    public Transform targetRail03;

    public TextMeshProUGUI txt_Score;
    public Image fiverBar;
    public GameObject LandObj;

    [SerializeField] float speed;
    [SerializeField] float posValue;

    Vector2 startPos01;
    Vector2 startPos02;
    Vector2 startPos03;
    float newPos01;
    float newPos02;
    float newPos03;

    float lv = 0;

    float smoothValue;
    float smoothSpeed = 10f;

    private void Start()
    {
        startPos01 = rail01.transform.position;
        startPos01.x += 327;

        startPos02 = rail02.transform.position;
        startPos02.x += 327;

        startPos03 = rail03.transform.position;
        startPos03.x += 327;

        InvokeRepeating("MakeFood01", 0f, 2f);

        InvokeRepeating("MakeHari", 0f, 2f);

        boardColor = scoreBoard.transform.GetChild(1).GetComponent<Image>().color;
    }

    private void Update()
    {
        if(MiniGameManager.Instance.GameOver == false)
        {
            rail01.color = new Color32(255, 255, 255, 255);
            newPos01 = Mathf.Repeat(Time.time * speed, posValue);
            rail01.transform.position = startPos01 + (Vector2.left * newPos01);
        }
        else
        {
            rail01.color = new Color32(77, 77, 77, 255);
            rail02.color = new Color32(77, 77, 77, 255);
            rail03.color = new Color32(77, 77, 77, 255);
            CancelInvoke("MakeFood01");
            CancelInvoke("MakeFood02");
            CancelInvoke("MakeFood03");
            CancelInvoke("MakeHari");
            lv = 0;
        }
       

        /*if (GameManager.Instance.railLv > 1)
        {
            newPos02 = Mathf.Repeat(Time.time * speed, posValue);
            rail02.transform.position = startPos02 + (Vector2.left * newPos02);
        }
        else if(GameManager.Instance.railLv > 2)
        {
            newPos03 = Mathf.Repeat(Time.time * speed, posValue);
            rail03.transform.position = startPos03 + (Vector2.left * newPos03);
        }*/
        if(lv > 0)
        {
            newPos02 = Mathf.Repeat(Time.time * speed, posValue);
            rail02.transform.position = startPos02 + (Vector2.left * newPos02);
            rail02.color = new Color32(255, 255, 255, 255);
        }
        if(lv > 1)
        {
            newPos03 = Mathf.Repeat(Time.time * speed, posValue);
            rail03.transform.position = startPos03 + (Vector2.left * newPos03);
            rail03.color = new Color32(255, 255, 255, 255);
        }

        if(MiniGameManager.Instance.isCorrect == 1)
        {
            if (smoothValue <= MiniGameManager.Instance.fiverScore)
            {
                smoothValue = Mathf.Lerp(fiverBar.fillAmount, MiniGameManager.Instance.fiverScore, Time.deltaTime * smoothSpeed);
                fiverBar.fillAmount = smoothValue;
                if (fiverBar.fillAmount >= 1)
                {
                    FiverTime();
                    MiniGameManager.Instance.isCorrect = 0;
                }
            }
            else
            {
                MiniGameManager.Instance.isCorrect = 0;
            }
            
        }else if(MiniGameManager.Instance.isCorrect == -1)
        {
            if(smoothValue >= 0)
            {
                smoothValue = Mathf.Lerp(fiverBar.fillAmount, MiniGameManager.Instance.fiverScore, Time.deltaTime * smoothSpeed);
                fiverBar.fillAmount = smoothValue;
            }
            else
            {
                MiniGameManager.Instance.isCorrect = 0;
            }
        }
        if(img_time.fillAmount > 0 && MiniGameManager.Instance.GameOver == false)
        {
            img_time.fillAmount -= Time.deltaTime;
        }else if(img_time.fillAmount <= 0 && MiniGameManager.Instance.GameOver == false)
        {
            scoreBoard.SetActive(true);
            //StartCoroutine(GameOver());
            MiniGameManager.Instance.GameOver = true;
        }

        if (scoreBoard.transform.GetChild(1).GetComponent<Image>().color.a > 0 || 
            MiniGameManager.Instance.GameOver == true)
        {
            StartCoroutine(GameOver());
            MiniGameManager.Instance.GameOver = false;
        }
        else if(scoreBoard.transform.GetChild(1).GetComponent<Image>().color.a <= 0)
        {
            scoreBoard.transform.GetChild(1).gameObject.SetActive(false);

            boardColor.a = 1f;
            scoreBoard.transform.GetChild(1).GetComponent<Image>().color = boardColor;
        }
    }

    public void lvUp()
    {
        Debug.Log(lv);

        if (lv == 0)
        {
            InvokeRepeating("MakeFood02", 0f, 2f);
        }
        else if (lv == 1)
        {
            InvokeRepeating("MakeFood03", 0f, 2f);
        }
        
        if(lv > 2)
        {
            rail02.color = new Color32(77, 77, 77, 255);
            rail03.color = new Color32(77, 77, 77, 255);
            CancelInvoke("MakeFood02");
            CancelInvoke("MakeFood03");
            lv = 0;
        }
        else
        {
            lv++;
        }
        
    }

    void MakeFood01()
    {
        this.GetComponent<FoodManager>().SpawnFood(targetRail01);
    }

    void MakeFood02()
    {
        this.GetComponent<FoodManager>().SpawnFood(targetRail02);
    }
    void MakeFood03()
    {
        this.GetComponent<FoodManager>().SpawnFood(targetRail03);
    }
    public void AddFoodScore()
    {
        MiniGameManager.Instance.isCorrect = 1;
        MiniGameManager.Instance.fiverScore += 0.1f;
        //GameManager.Instance.Score += 10;
        /*if ((MiniGameManager.Instance.fiverScore + 0.1f) >= 1)
        {
            FiverTime();
        }
        else
        {
            MiniGameManager.Instance.fiverScore += 0.1f;
            smoothValue = Mathf.Lerp(fiverBar.fillAmount, MiniGameManager.Instance.fiverScore, Time.deltaTime * smoothSpeed);
            fiverBar.fillAmount = smoothValue;
        }*/

        MiniGameManager.Instance.Score += 10;
        txt_Score.text = MiniGameManager.Instance.Score.ToString();
    }

    public void DelFoodScore()
    {
        MiniGameManager.Instance.isCorrect = -1;

        MiniGameManager.Instance.fiverScore = 0f;
        //fiverBar.fillAmount = MiniGameManager.Instance.fiverScore;
    }

    public void FiverTime()
    {
        MiniGameManager.Instance.fiverScore = 0;
        fiverBar.fillAmount = MiniGameManager.Instance.fiverScore;

        MiniGameManager.Instance.Score += 500;
        txt_Score.text = MiniGameManager.Instance.Score.ToString();

    }

    void MakeHari()
    {
        this.GetComponent<HariManager>().Born(LandObj);
    }

    public void GameStart()
    {
        img_time.fillAmount = MiniGameManager.Instance.PlayTime;
        
        /*
        startPos01 = rail01.transform.position;
        startPos01.x += 327;

        startPos02 = rail02.transform.position;
        startPos02.x += 327;

        startPos03 = rail03.transform.position;
        startPos03.x += 327;*/

        InvokeRepeating("MakeFood01", 0f, 2f);

        InvokeRepeating("MakeHari", 0f, 2f);

        boardColor.a = 1f;

        scoreBoard.SetActive(false);
        scoreBoard.transform.GetChild(1).gameObject.SetActive(true);
        scoreBoard.transform.GetChild(1).GetComponent<Image>().color = boardColor;
        MiniGameManager.Instance.GameOver = false;
    }

    public void PlayTimeCheck()
    {

    }

    IEnumerator GameOver()
    {
        boardColor.a -= Time.deltaTime * 0.3f;
        Debug.Log(boardColor.a);
        scoreBoard.transform.GetChild(1).GetComponent<Image>().color = boardColor;

        yield return new WaitForSeconds(0.1f);
    }

}
