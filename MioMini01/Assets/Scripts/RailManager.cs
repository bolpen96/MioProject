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

    float lv;

    public float score;

    private void Start()
    {
        startPos01 = rail01.transform.position;
        startPos01.x += 327;

        startPos02 = rail02.transform.position;
        startPos02.x += 327;

        startPos03 = rail03.transform.position;
        startPos03.x += 327;

        InvokeRepeating("MakeFood", 0f, 2f);

        InvokeRepeating("MakeHari", 0f, 5f);

    }

    private void Update()
    {
        newPos01 = Mathf.Repeat(Time.time * speed, posValue);
        rail01.transform.position = startPos01 + (Vector2.left * newPos01);

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

    }

    public void lvUp()
    {

        if (lv >= 3)
        {
            lv = 0;
        }
        else
        {
            lv++;
        }

        if (lv >= 0)
        {
            InvokeRepeating("MakeFood02", 0f, 2f);
        }
        if (lv > 1)
        {
            InvokeRepeating("MakeFood03", 0f, 2f);
        }
        else
        {
            rail02.color = new Color32(77, 77, 77, 255);
            rail03.color = new Color32(77, 77, 77, 255);
            CancelInvoke("MakeFood02");
            CancelInvoke("MakeFood03");
        }

    }

    void MakeFood()
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
    public void FoodScore()
    {

        //GameManager.Instance.Score += 10;
        if((fiverBar.fillAmount += 0.1f) == 1)
        {
            FiverTime();
        }
        else
        {
            fiverBar.fillAmount += 0.1f;
        }
        

        score += 10;
        txt_Score.text = score.ToString();
    }

    public void FiverTime()
    {
        fiverBar.fillAmount = 0;

        score += 500;
        txt_Score.text = score.ToString();

    }

    void MakeHari()
    {
        this.GetComponent<HariManager>().Born(LandObj);
    }

}
