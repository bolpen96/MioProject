using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Adventure : MonoBehaviour
{
    public static Adventure instance;
    public Image Img_topView;
    public GameObject obj_bottomView;

    public Sprite[] mioSprite;
    public GameObject mioTalk;
    public float mioHeath;
    public Image Img_mioHeath;
    /*
    0 : 선택지
    1 : 
     */
    public Sprite[] bgSprite;
    public TextMeshProUGUI txt_explane;
    public float currentType;

    public GameObject obj_chooseView;
    public GameObject obj_choose;
    
    public GameObject obj_resultView;
    public TextMeshProUGUI txt_resultExplane;
    public TextMeshProUGUI txt_resultEffect;

    public GameObject gameoverView;

    public int storyNum;
    public float storyScore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mioHeath = 1;               //미오 최대체력 설정
        storyScore = 10;            //스토리 진행 체력 설정
        gameoverView.SetActive(false);
    }

    public IEnumerator mioHeathBar(float num)
    {
        float smooth;
        mioHeath += num/100;

        Debug.Log(Img_mioHeath.fillAmount + " ||" + mioHeath);

        while (Img_mioHeath.fillAmount > mioHeath)
        {
            smooth = Mathf.Lerp(Img_mioHeath.fillAmount, mioHeath, Time.deltaTime * 10f);
            Img_mioHeath.fillAmount = smooth;

            if(Img_mioHeath.fillAmount < 0)
            {
                gameoverView.SetActive(true);
                break;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void watchAdd()
    {
        StartCoroutine(mioHeathUp(50));
        gameoverView.SetActive(false);
    }

    IEnumerator mioHeathUp(float num)
    {
        float smooth;
        mioHeath += num / 100;
        while (Img_mioHeath.fillAmount < mioHeath)
        {
            smooth = Mathf.Lerp(Img_mioHeath.fillAmount, mioHeath, Time.deltaTime * 10f);
            Img_mioHeath.fillAmount = smooth;

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void ExitAdventure()
    {
        GameManager.Instance.State = 3;
        SceneManager.LoadScene(1);
    }

}
