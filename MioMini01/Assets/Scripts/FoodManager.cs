using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] Food;

    
    int ranNum;

    public void SpawnFood(Transform parentObj)
    {
        ranNum = Random.Range(0,Food.Length-1);
        GameObject temp = Instantiate(Food[ranNum], parentObj);
        temp.transform.SetParent(parentObj);
    }

    
}
