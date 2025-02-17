using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    private CanvasScaler mainCanvasScaler;

    //default �ػ� ����
    float fixedAspectRatio = 9f / 16f;

    private void Awake()
    {
        mainCanvasScaler = this.GetComponent<CanvasScaler>();
    }

    // Start is called before the first frame update
    void Start()
    {

        //���� �ػ��� ����
        float currentAsperctRatio = (float)Screen.width / (float)Screen.height;

        //���� �ػ� ���κ����� �� �� ���
        if (currentAsperctRatio > fixedAspectRatio) mainCanvasScaler.matchWidthOrHeight = 1;
        //���� �ػ� ���� ������ �� �� ���
        else if (currentAsperctRatio < fixedAspectRatio) mainCanvasScaler.matchWidthOrHeight = 0;

        

    }
}
