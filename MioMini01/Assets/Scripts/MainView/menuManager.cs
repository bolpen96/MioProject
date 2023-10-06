using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public GameObject menuView;

    public void openMenu()
    {
        if(!menuView.activeSelf)
        {
            menuView.SetActive(true);
            menuView.transform.position =
                new Vector2(menuView.transform.position.x, Mathf.Lerp(1395.5f, 440.52f, Time.deltaTime * 5f));
        }
        else
        {
            menuView.SetActive(false);
            menuView.transform.position =
                new Vector2(menuView.transform.position.x, Mathf.Lerp(440.52f, 1395.5f, Time.deltaTime * 5f));
        }
        
    }


}
