using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HariManager : MonoBehaviour
{
    public Image[] emoticon;
    public Sprite[] food;

    int ranNum;

    public void Born(GameObject parentObj)
    {
        ranNum = Random.Range(0, food.Length);
        parentObj.GetComponent<Image>().sprite = food[ranNum];
        
    }

    public void Eat()
    {

    }
}
