using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayWithMio : MonoBehaviour
{
    public GameObject playing_View;
    public Scrollbar scrBar;
    public Transform tr_scrBar;
    public Image Img_zone;
    bool isPlayEnd;

    private void Update()
    {
        if(MainManager.instance.isPlaying)
        {
            scrBar.value -= Time.deltaTime * 0.2f;
            if (Input.GetMouseButtonUp(0))
            {
                scrBar.value += 0.05f;
            }

        }        
    }

    public void setPlay()
    {
        StartCoroutine(Playing());
    }

    public IEnumerator Playing()
    {
        scrBar.value = 1;
        MainManager.instance.isPlaying = true;

        GameObject createZone = Instantiate(Img_zone).gameObject;
        createZone.transform.SetParent(tr_scrBar, false);
        createZone.transform.SetAsFirstSibling();
        float ranPosX = Random.Range(-251, 241);

        createZone.transform.localPosition = new Vector3(ranPosX, createZone.transform.localPosition.y);

        while (MainManager.instance.PlayingTime > 0)
        {
            MainManager.instance.PlayingTime -= Time.deltaTime * 10f;
            if (scrBar.value <= 0)
            {
                MainManager.instance.isPlaying = false;
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
        
        MainManager.instance.isPlaying = false;
        isPlayEnd = true;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (!MainManager.instance.isPlaying && isPlayEnd)
        {
            



            isPlayEnd = false;
        }
    }
}
