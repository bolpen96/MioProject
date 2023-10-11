using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    int ranNum;
    int resultRanNum;
    string[] str_story;
    string[,] str_choose;
    string[] result_story;
    string[,] result_effect;
    string[] str_talk;

    GameObject objO;
    GameObject objS;
    GameObject objT;
    GameObject objF;

    int jungleHeart = 10;
    float lakeHeart = 50;

    float talkSpeed = 0.1f;

    public int ckNum;

    bool ckFirst;
    bool ckSecond;
    bool ckThird;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        str_story = new string[] 
        {
            "물,불,얼음의 길이 보인다 \n 어디로 갈까요?",    //0
            "앞에 물이 펼쳐져 있네요",                       //1
            "앞에 불이 펼쳐져 있네요",                       //2
            "앞에 얼음이 펼쳐져 있네요",                     //3
            "앞에 조심해야 할 것 같은 \n 정글이 나타났어요", //4
            "많은 열매가 보이는 숲이 나타났어요",            //5
            "신비한 기운의 옹달샘이 나타났어요",             //6
            "앞에 큰바람이 불고있네요",                      //7
            "점점 맑은 느낌이 드네요",                       //8
            "점점 따뜻한 느낌이 드네요",                     //9
            "점점 시원한 느낌이 드네요",                     //10
            "앞에 토네이도가 나타났어요",                    //11
            "의문에 상자가 나타났어요",                      //12
            "엄청 큰 생물체가 나타났어요"                    //13

        };

        str_choose = new string[,] 
        {
            {"물", "불", "얼음" },                                //0
            {"되돌아간다","건너간다",null },                      //1,2,3,4
            {"열매를 먹는다","그냥 건너간다",null },              //5
            {"물을 마신다","그냥 건너간다",null },                //6
            {"바람이 부는 곳으로 간다","다른데로 간다",null },    //7
            {"느낌이 나는 곳으로 간다","다른데로 간다",null },    //8,9,10
            {"구경한다","다른데로 간다",null },                   //11
            {"열어본다","그냥 다른데로 간다",null },              //12
            {"한대 톡 쳐본다","말을 걸어본다","다른데로 간다"}    //13
        };

        result_story = new string[]
        {
            "먹이를 찾았어요",                                         //0,1,2,3
            "건너가는 중에 상처가 났어요",                             //4
            "안전하게 건너왔어요",                                     //4
            "열매들을 매우 맛있게 먹었어요",                           //5
            "신기한 기운이 우리를 덮었고 \n 몸을 깨끗게 해주었어요",   //6
            "토네이도에서 날라온 물건에 의해 다쳤어요",                //11
            "토네이도에서 날라온 물건을 주웠어요",                     //11
            "각종 아이템이 들어있었어요",                              //12
            "비어있는 상자에요",                                       //12
            "상자에서 벌래들이 튀어나왔어요",                          //12
            "엄청 큰 생물체가 우리를 공격했어요",                      //13
            "아무 반응도 하지 않네요",                                 //13
            "무언가를 건내주었어요"                                    //13
        };

        result_effect = new string[,]
        {
            { "탱글탱글해보이는 먹이", "물에 부풀려있는 먹이"},      //1
            { "노릇노릇 구워진 먹이","타버린 먹이" },                //2
            { "신선해보이는 먹이", "얼어있는 먹이"},                 //3
            {"의 배고픔이 해결되었어요","" },                          //5
            {"의 체력이 회복하였어요","" },                            //6
            {"을(를) 획득하였어요" , ""},                                  //
            {"와 ","를 획득하였어요" },                                //
            {"체력이 "," 감소하였어요" },                              //
        };
    }

    public void SelectWay()
    {
        Adventure.instance.Img_topView.sprite = Adventure.instance.bgSprite[0];
        Adventure.instance.txt_explane.text = "어느방향으로 갈까요?";

        objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "동쪽으로";
        objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "서쪽으로";
        objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objT.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "남쪽으로";
        objF = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objF.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "북쪽으로";
        Adventure.instance.currentType = 1;
    }

    public void ChooseOne()
    {
        Destroy(objO);
        Destroy(objS);
        Destroy(objT);
        Destroy(objF);

        //최초 방향 선택
        if (Adventure.instance.currentType == 1)
        {
            ranNum = Random.Range(0, str_story.Length-1);

            Adventure.instance.txt_explane.text = str_story[ranNum];

            if (ranNum == 0)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[0, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[0, 1];
                objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objT.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[0, 2];
            }
            else if(ranNum < 5)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[1, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[1, 1];
            }
            else if(ranNum == 5)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[2, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[2, 1];
            }
            else if(ranNum == 6)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[3, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[3, 2];
            }
            else if (ranNum == 7)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[4, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[4, 1];
            }
            else if (ranNum < 11)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[5, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[5, 1];
            }
            else if (ranNum == 11)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[6, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[6, 1];
            }
            else if (ranNum == 12)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[7, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[7, 1];
            }
            else if (ranNum == 13)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[8, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[8, 1];
                objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objT.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[8, 2];
            }

            Adventure.instance.Img_topView.sprite = Adventure.instance.bgSprite[ranNum + 1];
            Adventure.instance.currentType = 2;
        }
        //결과 설명 문장
        else if(Adventure.instance.currentType == 2)
        {
            if(ranNum < 4)
            {
                if(ranNum == 0)
                {
                    ranNum = ckNum;
                    Adventure.instance.currentType = 1;
                    SelectWay();
                }
                else if(ckNum == 0)
                {
                    Adventure.instance.currentType = 1;
                    SelectWay();
                }
                else if(ranNum == 1)
                {
                    resultRanNum = Random.Range(0, 1);
                    //상호작용 텍스트
                    Adventure.instance.txt_resultEffect.text = result_effect[0,resultRanNum] + result_effect[5,0];
                }
                else if(ranNum == 2)
                {
                    resultRanNum = Random.Range(0, 1);
                    //상호작용 텍스트
                    Adventure.instance.txt_resultEffect.text = result_effect[1, resultRanNum] + result_effect[5, 0];
                }
                else if (ranNum == 3)
                {
                    resultRanNum = Random.Range(0, 1);
                    //상호작용 텍스트
                    Adventure.instance.txt_resultEffect.text = result_effect[2, resultRanNum] + result_effect[5, 0];
                }
                Adventure.instance.txt_resultExplane.text = result_story[0];

            }
            else if(ranNum == 4)
            {
                if (ckNum == 0)
                {
                    Adventure.instance.currentType = 1;
                    SelectWay();
                }

                resultRanNum = Random.Range(1, 2);
                Adventure.instance.txt_resultExplane.text = result_story[resultRanNum];
                if(resultRanNum == 1)
                {
                    Adventure.instance.txt_resultEffect.text = result_effect[7,0] + jungleHeart + result_effect[7,1];
                }
            }
            else if(ranNum == 5) 
            {
                Adventure.instance.txt_resultExplane.text = result_story[3];
                Adventure.instance.txt_resultEffect.text = result_effect[3, 0]; //수정 - 추후 미오 이름추가
            }
            else if(ranNum == 6)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if(ranNum < 11)
            {
                if (ckNum == 0)
                {
                    Adventure.instance.currentType = 1;
                    SelectWay();
                }
            }
            else if(ranNum == 7)
            {
                
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[1, 0];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = str_choose[1, 1];
                

                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if(ranNum == 8)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if (ranNum == 9)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if (ranNum == 10)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if (ranNum == 8)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if (ranNum == 8)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }
            else if (ranNum == 8)
            {
                Adventure.instance.txt_resultExplane.text = result_story[4];
                Adventure.instance.txt_resultEffect.text = lakeHeart + result_effect[4, 0];
            }

            Adventure.instance.currentType = 3;
        }
        
        //체력이 다 소모되었을 때
        
    }

    

    IEnumerator FademioTalk()
    {
        Adventure.instance.mioTalk.SetActive(true);

        while (Adventure.instance.mioTalk.GetComponent<Image>().fillAmount > 0)
        {
            Adventure.instance.mioTalk.GetComponent<Image>().fillAmount -= Time.deltaTime * talkSpeed;
            yield return new WaitForSeconds(0.1f);
        }

        Adventure.instance.mioTalk.SetActive(false);
        yield return null;
    }

    
    
}
