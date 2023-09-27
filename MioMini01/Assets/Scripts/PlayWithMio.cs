using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayWithMio : MonoBehaviour
{
    public GameObject PlayingView;
    public Image Img_play;
    public Scrollbar scrBar;
    public Transform tr_scrBar;
    public Image Img_zone;
    bool isPlaycool;
    public VideoPlayer Vp;
    public VideoClip[] clip;

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
        StartCoroutine(PlayCoolTime());
    }

    //³î¾ÆÁÖ´Â ÀÌº¥Æ®
    public IEnumerator Playing()
    {
        scrBar.value = 1;
        MainManager.instance.isPlaying = true;
        onPlayVideo();
        GameObject createZone = Instantiate(Img_zone).gameObject;
        createZone.transform.SetParent(tr_scrBar, false);
        createZone.transform.SetAsFirstSibling();
        float ranPosX = UnityEngine.Random.Range(-251, 241);

        createZone.transform.localPosition = new Vector3(ranPosX, createZone.transform.localPosition.y);

        while (MainManager.instance.PlayingTime > 0)
        {
            MainManager.instance.PlayingTime -= Time.deltaTime * 10f;
            Debug.Log(MainManager.instance.PlayingTime);
            if (scrBar.value <= 0)
            {
                MainManager.instance.isPlaying = false;
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }

        Vp.Stop();
        MainManager.instance.isPlaying = false;
        PlayingView.SetActive(false);
        yield return null;
    }

    //³î¾ÆÁÖ±â ÄðÅ¸ÀÓ
    IEnumerator PlayCoolTime()
    {
        Img_play.GetComponent<Button>().interactable = false;
        Img_play.fillAmount = 0;

        while(Img_play.fillAmount < 1)
        {
            Img_play.fillAmount += Time.deltaTime * 0.1f;

            yield return new WaitForSeconds(0.1f);
        }

        Img_play.GetComponent<Button>().interactable = true;
        yield return null;
    }

    void onPlayVideo()
    {
        int ranNum = UnityEngine.Random.Range(0, 2);


        Vp.clip = clip[ranNum];

        Vp.Play();
    }
}
