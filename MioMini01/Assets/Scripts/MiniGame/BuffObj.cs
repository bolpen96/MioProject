using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffObj : MonoBehaviour
{
    Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.transform.GetChild(0).GetComponent<Image>().sprite;
        Debug.Log(sprite.name + "\n" + this.transform.GetChild(0));
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.GetChild(0).GetComponent<Image>().fillAmount -= Time.deltaTime * 0.1f;

        if(this.transform.GetChild(0).GetComponent<Image>().fillAmount <= 0 && !MiniGameManager.Instance.GameOver)
        {
            if(sprite.name == "food")
            {
                MiniGameManager.Instance.foodBuffOn = false;
                GameObject.Find("RailManager").GetComponent<RailManager>().foodBuff();
            }
            else if(sprite.name == "mio")
            {
                MiniGameManager.Instance.mioBuffOn = false;
                GameObject.Find("RailManager").GetComponent<RailManager>().mioBuff();
            }
            else if(sprite.name == "score")
            {
                MiniGameManager.Instance.scoreBuffOn = false;
                GameObject.Find("RailManager").GetComponent<RailManager>().scoreBuff();
            }
            else if(sprite.name == "fiver")
            {
                MiniGameManager.Instance.fiverBuffOn = false;
                GameObject.Find("RailManager").GetComponent<RailManager>().fiverBuff();
            }


            Destroy(this.gameObject);
        }

        if(MiniGameManager.Instance.GameOver)
        {
            Destroy(this.gameObject);
        }
    }
}
