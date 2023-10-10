using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    int ranNum;
    int resultRanNum;
    public Sprite[] sp_bg;
    string[] str_story;
    string[,] str_choose;
    string[] result_story;
    string[,] result_effect;

    GameObject objO;
    GameObject objS;
    GameObject objT;
    GameObject objF;

    private void Start()
    {
        str_story = new string[] 
        {
            "물,불,얼음의 길이 보인다 \n 어디로 갈까?",    //0
            "앞에 물이 펼쳐져 있다",                       //1
            "앞에 불이 펼쳐져 있다",                       //2
            "앞에 얼음이 펼쳐져 있다",                     //3
            "앞에 조심해야 할 것 같은 \n 것들이 나타났다", //4
            "많은 열매가 보이는 숲이 나타났다",            //5
            "신비한 기운의 옹달샘이 나타났다",             //6
            "앞에 큰바람이 불고있다",                      //7
            "점점 따뜻한 느낌이 든다",                     //8
            "점점 시원한 느낌이 든다",                     //9
            "점점 맑은 느낌이 든다",                       //10
            "앞에 토네이도가 나타났다",                    //11
            "의문에 상자가 나타났다",                      //12
            "엄청 큰 생물체가 나타났다"                    //13

        };

        str_choose = new string[,] 
        {
            { "물", "불", "얼음" },                               //0
            {"되돌아간다","건너간다",null },                      //1,2,3,4
            {"열매를 먹는다","그냥 건너간다",null },              //5
            { "물을 마신다","그냥 건너간다",null },               //6
            {"바람이 부는 곳으로 간다","다른데로 간다",null },    //7
            {"느낌이 나는 곳으로 간다","다른데로 간다",null },    //8,9,10
            {"구경한다","다른데로 간다",null },                   //11
            {"열어본다","그냥 다른데로 간다",null },              //12
            {"한대 톡 쳐본다","말을 걸어본다","다른데로 간다"}    //13
        };

        result_story = new string[]
        {
            "먹이를 찾았다",                                         //0,1,2,3
            "건너가는 중에 상처가 났다",                             //4
            "안전하게 건너왔다",                                     //4
            "열매들을 매우 맛있게 먹었다",                           //5
            "신기한 기운이 우리를 덮었고 \n 몸을 깨끗게 해주었다",   //6
            "토네이도에서 날라온 물건에 의해 다쳤다",                //11
            "토네이도에서 날라온 물건을 주웠다",                     //11
            "각종 아이템이 들어있었다",                              //12
            "비어있는 상자다",                                       //12
            "상자에서 벌래들이 튀어나왔다",                          //12
            "엄청 큰 생물체가 우리를 공격했다",                      //13
            "아무 반응을 하지않는다",                                //13
            "무언가를 건내주었다"                                    //13
        };

        result_effect = new string[,]
        {
            { "탱글탱글해보이는 먹이", "물에 부풀려있는 먹이"},      //1
            { "노릇노릇 구워진 먹이","타버린 먹이" },                //2
            { "신선해보이는 먹이", "얼어있는 먹이"},                 //3
            {"의 배고픔이 해결되었다","" },                          //5
            {"의 체력이 회복하였다","" },                            //6
            {"을 획득하였다" , ""},                                  //
            {"와 ","를 획득하였다" },                                //
            {"체력이 "," 감소하였다" },                              //
        };
    }

    public void SelectWay(Image img_bg, TextMeshProUGUI txt_explane, GameObject obj_choose, Transform obj_parent)
    {
        img_bg.sprite = Adventure.instance.bgSprite[0];
        txt_explane.text = "which way do you like";

        objO = Instantiate(obj_choose, obj_parent);

        /*objO.transform.GetChild(0).GetComponent<TextMeshPro>().text = "east";
        objS = Instantiate(obj_choose, obj_parent);
        objS.transform.GetChild(0).GetComponent<TextMeshPro>().text = "west";
        objT = Instantiate(obj_choose, obj_parent);
        objT.transform.GetChild(0).GetComponent<TextMeshPro>().text = "south";
        objF = Instantiate(obj_choose, obj_parent);
        objF.transform.GetChild(0).GetComponent<TextMeshPro>().text = "north";*/
        Adventure.instance.currentType = 1;
    }

    public void SouthStory(Image img_bg, TextMeshProUGUI txt_explane, GameObject obj_choose)
    {
        ranNum = Random.Range(0, 4);

        img_bg.sprite = sp_bg[ranNum];

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
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[0, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[0, 2];
                objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objT.transform.GetChild(0).GetComponent<Text>().text = str_choose[0, 3];
            }
            else if(ranNum < 5)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[1, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[1, 2];
            }
            else if(ranNum == 5)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[2, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[2, 2];
            }
            else if(ranNum == 6)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[3, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[3, 2];
            }
            else if (ranNum == 7)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[4, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[4, 2];
            }
            else if (ranNum < 11)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[5, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[5, 2];
            }
            else if (ranNum == 11)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[6, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[6, 2];
            }
            else if (ranNum == 12)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[7, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[7, 2];
            }
            else if (ranNum == 13)
            {
                objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objO.transform.GetChild(0).GetComponent<Text>().text = str_choose[4, 1];
                objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objS.transform.GetChild(0).GetComponent<Text>().text = str_choose[4, 2];
                objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.obj_chooseView.transform);
                objT.transform.GetChild(0).GetComponent<Text>().text = str_choose[4, 3];
            }

            Adventure.instance.currentType = 2;
        }
        //결과 설명 문장
        else if(Adventure.instance.currentType == 2)
        {
            if(ranNum < 4)
            {
                //결과 설명 텍스트
                Adventure.instance.txt_explane.text = result_story[0];
                if(ranNum == 1)
                {
                    resultRanNum = Random.Range(0, 1);
                    //상호작용 텍스트
                    Adventure.instance.txt_resultEffect.text = result_story[resultRanNum];
                }
            }
            else if(ranNum == 4)
            {
                resultRanNum = Random.Range(0, 1);
                Adventure.instance.txt_explane.text = result_story[resultRanNum];
            }
        }
    }

    
}
