using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    private CanvasScaler mainCanvasScaler;

    //default 해상도 비율
    float fixedAspectRatio = 9f / 16f;

    private void Awake()
    {
        mainCanvasScaler = this.GetComponent<CanvasScaler>();
    }

    // Start is called before the first frame update
    void Start()
    {

        //현재 해상도의 비율
        float currentAsperctRatio = (float)Screen.width / (float)Screen.height;

        //현재 해상도 가로비율이 더 길 경우
        if (currentAsperctRatio > fixedAspectRatio) mainCanvasScaler.matchWidthOrHeight = 1;
        //현재 해상도 세로 비율이 더 길 경우
        else if (currentAsperctRatio < fixedAspectRatio) mainCanvasScaler.matchWidthOrHeight = 0;

        

    }
}
