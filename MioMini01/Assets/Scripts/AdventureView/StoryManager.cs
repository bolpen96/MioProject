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
            "��,��,������ ���� ���δ� \n ���� �����?",    //0
            "�տ� ���� ������ �ֳ׿�",                       //1
            "�տ� ���� ������ �ֳ׿�",                       //2
            "�տ� ������ ������ �ֳ׿�",                     //3
            "�տ� �����ؾ� �� �� ���� \n ������ ��Ÿ�����", //4
            "���� ���Ű� ���̴� ���� ��Ÿ�����",            //5
            "�ź��� ����� �˴޻��� ��Ÿ�����",             //6
            "�տ� ū�ٶ��� �Ұ��ֳ׿�",                      //7
            "���� ���� ������ ��׿�",                       //8
            "���� ������ ������ ��׿�",                     //9
            "���� �ÿ��� ������ ��׿�",                     //10
            "�տ� ����̵��� ��Ÿ�����",                    //11
            "�ǹ��� ���ڰ� ��Ÿ�����",                      //12
            "��û ū ����ü�� ��Ÿ�����"                    //13

        };

        str_choose = new string[,] 
        {
            {"��", "��", "����" },                                //0
            {"�ǵ��ư���","�ǳʰ���",null },                      //1,2,3,4
            {"���Ÿ� �Դ´�","�׳� �ǳʰ���",null },              //5
            {"���� ���Ŵ�","�׳� �ǳʰ���",null },                //6
            {"�ٶ��� �δ� ������ ����","�ٸ����� ����",null },    //7
            {"������ ���� ������ ����","�ٸ����� ����",null },    //8,9,10
            {"�����Ѵ�","�ٸ����� ����",null },                   //11
            {"�����","�׳� �ٸ����� ����",null },              //12
            {"�Ѵ� �� �ĺ���","���� �ɾ��","�ٸ����� ����"}    //13
        };

        result_story = new string[]
        {
            "���̸� ã�Ҿ��",                                         //0,1,2,3
            "�ǳʰ��� �߿� ��ó�� �����",                             //4
            "�����ϰ� �ǳʿԾ��",                                     //4
            "���ŵ��� �ſ� ���ְ� �Ծ����",                           //5
            "�ű��� ����� �츮�� ������ \n ���� ������ ���־����",   //6
            "����̵����� ����� ���ǿ� ���� ���ƾ��",                //11
            "����̵����� ����� ������ �ֿ����",                     //11
            "���� �������� ����־����",                              //12
            "����ִ� ���ڿ���",                                       //12
            "���ڿ��� �������� Ƣ��Ծ��",                          //12
            "��û ū ����ü�� �츮�� �����߾��",                      //13
            "�ƹ� ������ ���� �ʳ׿�",                                 //13
            "���𰡸� �ǳ��־����"                                    //13
        };

        result_effect = new string[,]
        {
            { "�ʱ��ʱ��غ��̴� ����", "���� ��Ǯ���ִ� ����"},      //1
            { "�븩�븩 ������ ����","Ÿ���� ����" },                //2
            { "�ż��غ��̴� ����", "����ִ� ����"},                 //3
            {"�� ������� �ذ�Ǿ����","" },                          //5
            {"�� ü���� ȸ���Ͽ����","" },                            //6
            {"��(��) ȹ���Ͽ����" , ""},                                  //
            {"�� ","�� ȹ���Ͽ����" },                                //
            {"ü���� "," �����Ͽ����" },                              //
        };
    }

    public void SelectWay()
    {
        Adventure.instance.Img_topView.sprite = Adventure.instance.bgSprite[0];
        Adventure.instance.txt_explane.text = "����������� �����?";

        objO = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objO.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��������";
        objS = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objS.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��������";
        objT = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objT.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��������";
        objF = Instantiate(Adventure.instance.obj_choose, Adventure.instance.Img_topView.transform);
        objF.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��������";
        Adventure.instance.currentType = 1;
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
        //��� ���� ����
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
                    //��ȣ�ۿ� �ؽ�Ʈ
                    Adventure.instance.txt_resultEffect.text = result_effect[0,resultRanNum] + result_effect[5,0];
                }
                else if(ranNum == 2)
                {
                    resultRanNum = Random.Range(0, 1);
                    //��ȣ�ۿ� �ؽ�Ʈ
                    Adventure.instance.txt_resultEffect.text = result_effect[1, resultRanNum] + result_effect[5, 0];
                }
                else if (ranNum == 3)
                {
                    resultRanNum = Random.Range(0, 1);
                    //��ȣ�ۿ� �ؽ�Ʈ
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
                Adventure.instance.txt_resultEffect.text = result_effect[3, 0]; //���� - ���� �̿� �̸��߰�
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
        
        //ü���� �� �Ҹ�Ǿ��� ��
        
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
