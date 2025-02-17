using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.PharmingMapSceneMove();
        GameManager.instance.getInventory();
    }

}
