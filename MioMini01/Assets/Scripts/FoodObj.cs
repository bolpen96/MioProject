using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObj : MonoBehaviour
{
    float speed = 200;

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

        Destroy(this.gameObject);
    }
}
