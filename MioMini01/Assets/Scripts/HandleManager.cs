using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (MainManager.instance.PlayingTime <= 0)
        {
            if(collision.gameObject.name == "Img_perfact")
            {
                MainManager.instance.result_zone = 1;
            }
            else if(collision.gameObject.name == "Img_good")
            {
                MainManager.instance.result_zone = 0;
            }
            else
            {
                MainManager.instance.result_zone = -1;
            }

        }
        
    }
}
