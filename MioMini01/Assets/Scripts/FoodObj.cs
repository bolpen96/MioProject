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

        GameObject[] mio = GameObject.FindGameObjectsWithTag("WantFood");

        if(MiniGameManager.Instance.IsFiver == false)
        {
            if (mio.Length == 0)
            {
                Debug.Log("없어요");
                return;
            }

            Destroy(this.gameObject);

            //정확한 음식을 주었을 때
            for (int i = 0; i < mio.Length; i++)
            {

                if (mio[i].GetComponent<Image>().sprite == food)
                {
                    obj.GetComponent<RailManager>().AddFoodScore();
                    ranHappy = UnityEngine.Random.Range(0, MiniGameManager.Instance.H_Icon.Length);
                    mio[i].GetComponent<Image>().sprite = MiniGameManager.Instance.H_Icon[ranHappy];
                    mio[i].tag = "Untagged";
                    Destroy(mio[i].transform.parent.transform.parent.gameObject, 3f);
                    return;
                }
            }

            //정확한 음식을 주지 않았을 때
            for (int j = 0; j < mio.Length; j++)
            {
                obj.GetComponent<RailManager>().DelFoodScore();
                ranNone = UnityEngine.Random.Range(0, mio.Length - 1);
                ranSad = UnityEngine.Random.Range(0, MiniGameManager.Instance.S_Icon.Length);
                mio[ranNone].GetComponent<Image>().sprite = MiniGameManager.Instance.S_Icon[ranSad];
                mio[ranNone].tag = "Untagged";
                Destroy(mio[ranNone].transform.parent.transform.parent.gameObject, 3f);
                return;
            }
        }
        else if(MiniGameManager.Instance.IsFiver)
        {
            obj.GetComponent<RailManager>().FiverScore();
            Destroy(this.gameObject);
            return;
        }

        

    }
}
