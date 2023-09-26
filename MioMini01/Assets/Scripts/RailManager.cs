using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RailManager : MonoBehaviour
{
    public Image rail01;
    public Image rail02;
    public Image rail03;

    public Image img_time;
    public GameObject scoreBoard;

    public GameObject FiverMio;
    bool fiverActS = false;
    bool fiverActE = false;

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

    public TextMeshProUGUI txt_tkValue;
    public TextMeshProUGUI txt_tkTime;

    public GameObject alert_Gamestart;

    private void Start()
    {
        startPos01 = rail01.transform.position;
        startPos01.x += 327;

        startPos02 = rail02.transform.position;
        startPos02.x += 327;

        startPos03 = rail03.transform.position;
        startPos03.x += 327;

        alert_Gamestart.SetActive(true);
    }

    private void Update()
    {
        if(MiniGameManager.Instance.GameOver == false && scoreBoard.activeSelf == false)
        {
            rail01.color = new Color32(255, 255, 255, 255);
            newPos01 = Mathf.Repeat(Time.time * speed, posValue);
            rail01.transform.position = startPos01 + (Vector2.left * newPos01);
        }
       
        if(MiniGameManager.Instance.Score >= 300)
        {
            
        }else if(MiniGameManager.Instance.Score >= 700)
        {

        }

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

        //일반 상황
        if(MiniGameManager.Instance.isCorrect == 1 && MiniGameManager.Instance.IsFiver == false)
        {
            if (smoothValue <= MiniGameManager.Instance.fiverScore)
            {
                smoothValue = Mathf.Lerp(fiverBar.fillAmount, MiniGameManager.Instance.fiverScore, Time.deltaTime * smoothSpeed);
                fiverBar.fillAmount = smoothValue;
                if (fiverBar.fillAmount >= 1)
                {
                    MiniGameManager.Instance.IsFiver = true;
                    fiverActS = true;
                    fiverActE = false;
                }
            }
            else
            {
                MiniGameManager.Instance.isCorrect = 0;
            }
            
        }
        else if(MiniGameManager.Instance.isCorrect == -1)
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
        //피버타임
        else if(MiniGameManager.Instance.IsFiver == true)
        {
            if(fiverActS == true)
            {
                FiverTime();
                MiniGameManager.Instance.isCorrect = 0;
                MiniGameManager.Instance.fiverScore = 0;
                fiverActS = false;
            }

            if (fiverBar.fillAmount > MiniGameManager.Instance.fiverScore)
            {
                fiverBar.fillAmount -= Time.deltaTime * 0.1f;
            }
            else
            {
                if(fiverActE == false)
                {
                    FiverEnd();
                    fiverActE = true;
                }
            }
        }


        if(img_time.fillAmount > 0 && MiniGameManager.Instance.GameOver == false)
        {
            img_time.fillAmount -= Time.deltaTime / MiniGameManager.Instance.PlayTime;
        }
        else if(img_time.fillAmount <= 0 && MiniGameManager.Instance.GameOver == false &&
            scoreBoard.activeSelf == false)
        {
            scoreBoard.SetActive(true);
            ObjectClear();
            GameOver();
            this.GetComponent<GameOverManager>().GameOver();
            MiniGameManager.Instance.GameOver = true;
            

        }

        MainManager.instance.showTokenTxt(txt_tkValue, txt_tkTime);

        //스코어 보드의 터치를 통한 빠른 상호작용
        if (scoreBoard.activeSelf && !this.GetComponent<GameOverManager>().coinCheck)
        {
            if (Input.GetMouseButton(0))
            {
                //this.GetComponent<GameOverManager>().fastScoreBoard();
                this.GetComponent<GameOverManager>().coinCheck = true;
            }
        }
        
    }

    //레일 추가 이벤트
    public void lvUp()
    {
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

    //음식 소환
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

    //음식 먹었을 때 이벤트
    public void AddFoodScore()
    {
        MiniGameManager.Instance.isCorrect = 1;
        MiniGameManager.Instance.fiverScore += 0.1f;

        MiniGameManager.Instance.Score += 10;
        txt_Score.text = MiniGameManager.Instance.Score.ToString();
    }

    //음식을 잘못먹였을 때 이벤트
    public void DelFoodScore()
    {
        MiniGameManager.Instance.isCorrect = -1;

        MiniGameManager.Instance.fiverScore = 0f;
    }

    //피버타임때 
    public void FiverScore()
    {
        MiniGameManager.Instance.Score += 20;
        txt_Score.text = MiniGameManager.Instance.Score.ToString();
    }
    public void FiverTime()
    {
        CancelInvoke("MakeFood01");
        
        MiniGameManager.Instance.Score += 500;
        txt_Score.text = MiniGameManager.Instance.Score.ToString();

        CancelInvoke("MakeMio");
        
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag("Mio");
        foreach(GameObject oneObject in destroyObject)
        {
            Destroy(oneObject);
        }
        FiverMio.SetActive(true);

        InvokeRepeating("MakeFood01", 0f, 0.5f);
        if (IsInvoking("MakeFood02"))
        {
            CancelInvoke("MakeFood02");
            InvokeRepeating("MakeFood02", 0f, 0.5f);
        }
        if (IsInvoking("MakeFood03"))
        {
            CancelInvoke("MakeFood03");
            InvokeRepeating("MakeFood03", 0f, 0.5f);
        }

    }

    //피버가 끝날 때
    void FiverEnd()
    {
        CancelInvoke("MakeFood01");
        
        InvokeRepeating("MakeFood01", 0f, 2f);

        if (IsInvoking("MakeFood02"))
        {
            CancelInvoke("MakeFood02");
            InvokeRepeating("MakeFood02", 0f, 2f);
        }
        if (IsInvoking("MakeFood03"))
        {
            CancelInvoke("MakeFood03");
            InvokeRepeating("MakeFood03", 0f, 2f);
        }

        InvokeRepeating("MakeMio", 0f, 2f);

        FiverMio.SetActive(false);
        fiverBar.fillAmount = 0;
        MiniGameManager.Instance.fiverScore = 0;
        MiniGameManager.Instance.IsFiver = false;
    }

    //미오 생성 이벤트
    void MakeMio()
    {
        this.GetComponent<HariManager>().Born(LandObj);
    }

    //게임시작 이벤트
    public void GameStart()
    {
        if(GameManager.Instance.Tokken > 0)
        {
            img_time.fillAmount = 1;
            fiverBar.fillAmount = 0;


            InvokeRepeating("MakeFood01", 0f, 2f);

            InvokeRepeating("MakeMio", 0f, 2f);

            scoreBoard.SetActive(false);
            MiniGameManager.Instance.GameOver = false;

            GameManager.Instance.Tokken--;
        }
        else
        {
            
        }
        
    }

    
    public void PlayTimeCheck()
    {

    }
    
    //게임오버 이벤트
    void GameOver()
    {
        rail01.color = new Color32(77, 77, 77, 255);
        rail02.color = new Color32(77, 77, 77, 255);
        rail03.color = new Color32(77, 77, 77, 255);
        CancelInvoke("MakeFood01");
        CancelInvoke("MakeFood02");
        CancelInvoke("MakeFood03");
        CancelInvoke("MakeMio");
        lv = 0;





        MiniGameManager.Instance.GameOver = false;

    }

    //오브젝트 클리어
    void ObjectClear()
    {
        GameObject[] destroyMio;
        GameObject[] destroyFood;
        destroyMio = GameObject.FindGameObjectsWithTag("Mio");
        destroyFood = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject oneObject in destroyMio)
        {
            Destroy(oneObject);
        }

        foreach(GameObject oneObject in destroyFood)
        {
            Destroy(oneObject);
        }
    }

}