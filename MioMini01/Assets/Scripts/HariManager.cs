using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HariManager : MonoBehaviour
{
    public GameObject mio;
    public Sprite[] food;

    int ranNum;

    float width;
    float height;

    float ranWidth;
    float ranHeight;



    //ㅁㅇ 소환
    public void Born(GameObject parentObj)
    {
        width = parentObj.GetComponent<RectTransform>().rect.width;
        height = parentObj.GetComponent<RectTransform>().rect.height;
        ranWidth = Random.Range(-443,355);
        ranHeight = Random.Range(-287, 197);
        

        ranNum = Random.Range(0, food.Length);
                 
        GameObject temp = Instantiate(mio, parentObj.transform);
        
        //말풍선의 음식 표시
        mio.transform.Find("Img_think").GetChild(0).GetComponent<Image>().sprite = food[ranNum];

        //부모 오브젝트의 일정한 위치로 이동
        temp.transform.localPosition = new Vector2(ranWidth, ranHeight);
    }

}
