using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodObj : MonoBehaviour
{
    float speed = 200;

    int ranHappy;
    int ranSad;
    int ranNone;

    Sprite food;

    int nonNum = 0;
    int[] nonFood;

    private void Start()
    {
        food = this.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(this.transform.position.x < -(Screen.width) / 2)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void OnClickEvent()
    {
        GameObject obj = GameObject.Find("RailManager");

        obj.GetComponent<RailManager>().FoodScore();

        GameObject[] mio = GameObject.FindGameObjectsWithTag("WantFood");

        Destroy(this.gameObject);

        for (int i = 0; i < mio.Length; i++)
        {
            //정확한 음식을 주었을 때
            if (mio[i].GetComponent<Image>().sprite == food)
            {
                ranHappy = UnityEngine.Random.Range(0, MiniGameManager.Instance.H_Icon.Length - 1);
                mio[i].GetComponent<Image>().sprite = MiniGameManager.Instance.H_Icon[ranHappy];
                mio[i].tag = "Untagged";
                Destroy(mio[i].transform.parent.transform.parent.gameObject,3f);
                return;
            }
        }

        for(int j = 0; j < mio.Length; j++)
        {
            ranNone = UnityEngine.Random.Range(0, mio.Length - 1);
            ranSad = UnityEngine.Random.Range(0, MiniGameManager.Instance.S_Icon.Length - 1);
            mio[ranNone].GetComponent<Image>().sprite = MiniGameManager.Instance.S_Icon[ranSad];
            mio[ranNone].tag = "Untagged";
            Destroy(mio[ranNone].transform.parent.transform.parent.gameObject, 3f);
            return;
        }

    }
}
