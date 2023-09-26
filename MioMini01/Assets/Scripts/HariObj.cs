using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HariObj : MonoBehaviour
{
    int ranNum;
    private void Awake()
    {
        ranNum = Random.Range(0, MiniGameManager.Instance.S_Icon.Length);
        if (Time.deltaTime > 10)
        {
            this.GetComponent<Image>().sprite = MiniGameManager.Instance.S_Icon[ranNum];
            this.tag = "Untagged";
            Destroy(this.gameObject, 3f);
        }
    }

}
