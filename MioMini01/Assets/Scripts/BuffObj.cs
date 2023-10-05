using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.1f / MiniGameManager.Instance.buffTime;

        if(this.transform.GetChild(0).GetComponent<Image>().fillAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
