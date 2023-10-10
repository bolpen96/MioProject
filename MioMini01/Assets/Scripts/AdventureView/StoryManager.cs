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
            "��,��,������ ���� ���δ� \n ���� ����?",    //0
            "�տ� ���� ������ �ִ�",                       //1
            "�տ� ���� ������ �ִ�",                       //2
            "�տ� ������ ������ �ִ�",                     //3
            "�տ� �����ؾ� �� �� ���� \n �͵��� ��Ÿ����", //4
            "���� ���Ű� ���̴� ���� ��Ÿ����",            //5
            "�ź��� ����� �˴޻��� ��Ÿ����",             //6
            "�տ� ū�ٶ��� �Ұ��ִ�",                      //7
            "���� ������ ������ ���",                     //8
            "���� �ÿ��� ������ ���",                     //9
            "���� ���� ������ ���",                       //10
            "�տ� ����̵��� ��Ÿ����",                    //11
            "�ǹ��� ���ڰ� ��Ÿ����",                      //12
            "��û ū ����ü�� ��Ÿ����"                    //13

        };

        str_choose = new string[,] 
        {
            { "��", "��", "����" },                               //0
            {"�ǵ��ư���","�ǳʰ���",null },                      //1,2,3,4
            {"���Ÿ� �Դ´�","�׳� �ǳʰ���",null },              //5
            { "���� ���Ŵ�","�׳� �ǳʰ���",null },               //6
            {"�ٶ��� �δ� ������ ����","�ٸ����� ����",null },    //7
            {"������ ���� ������ ����","�ٸ����� ����",null },    //8,9,10
            {"�����Ѵ�","�ٸ����� ����",null },                   //11
            {"�����","�׳� �ٸ����� ����",null },              //12
            {"�Ѵ� �� �ĺ���","���� �ɾ��","�ٸ����� ����"}    //13
        };

        result_story = new string[]
        {
            "���̸� ã�Ҵ�",                                         //0,1,2,3
            "�ǳʰ��� �߿� ��ó�� ����",                             //4
            "�����ϰ� �ǳʿԴ�",                                     //4
            "���ŵ��� �ſ� ���ְ� �Ծ���",                           //5
            "�ű��� ����� �츮�� ������ \n ���� ������ ���־���",   //6
            "����̵����� ����� ���ǿ� ���� ���ƴ�",                //11
            "����̵����� ����� ������ �ֿ���",                     //11
            "���� �������� ����־���",                              //12
            "����ִ� ���ڴ�",                                       //12
            "���ڿ��� �������� Ƣ��Դ�",                          //12
            "��û ū ����ü�� �츮�� �����ߴ�",                      //13
            "�ƹ� ������ �����ʴ´�",                                //13
            "���𰡸� �ǳ��־���"                                    //13
        };

        result_effect = new string[,]
        {
            { "�ʱ��ʱ��غ��̴� ����", "���� ��Ǯ���ִ� ����"},      //1
            { "�븩�븩 ������ ����","Ÿ���� ����" },                //2
            { "�ż��غ��̴� ����", "����ִ� ����"},                 //3
            {"�� ������� �ذ�Ǿ���","" },                          //5
            {"�� ü���� ȸ���Ͽ���","" },                            //6
            {"�� ȹ���Ͽ���" , ""},                                  //
            {"�� ","�� ȹ���Ͽ���" },                                //
            {"ü���� "," �����Ͽ���" },                              //
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

        //���� ���� ����
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
        //��� ���� ����
        else if(Adventure.instance.currentType == 2)
        {
            if(ranNum < 4)
            {
                //��� ���� �ؽ�Ʈ
                Adventure.instance.txt_explane.text = result_story[0];
                if(ranNum == 1)
                {
                    resultRanNum = Random.Range(0, 1);
                    //��ȣ�ۿ� �ؽ�Ʈ
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
