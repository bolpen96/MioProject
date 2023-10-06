using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (MainManager.instance.isPlaying)
        {
            if(collision.gameObject.name == "Img_perfact")
            {
                MainManager.instance.Play_result = 1;
            }
            else if(collision.gameObject.name == "Img_good")
            {
                MainManager.instance.Play_result = 0;
            }
            else
            {
                MainManager.instance.Play_result = -1;
            }
        }
        
        
    }
}
