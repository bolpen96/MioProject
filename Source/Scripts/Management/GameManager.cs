using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Character;
    public GameObject Player;
    public GameObject TouchPos;
    public GameObject mainCanvas;

    public FixedJoystick stick;

    public AudioClip[] BackgroundMusic;


    public float Level;
    public float Exp;
    public float Health;

    public bool OnAlert;
    public bool SceneSet;

    public GameObject resultObject;
    public Inventory inventory;

    public Sprite[] Flower;
    public Sprite[] Tree;

    //����ǥ�� �Լ�
    public TextMeshProUGUI CurrencyText;
    public TextMeshProUGUI ShopMoneyText;
    public TextMeshProUGUI ShopMoneyCashText;

    public long PlayerCurrency;


    private void Awake()
    {
        instance = this;
        setLandscapeLeft();
        DontDestroyOnLoad(this);

        //�ʱ⼳��
        OnAlert = true;
    }

    private void Start()
    {
        defaultSetting();
    }

    //ȭ���� ���ι������� ����
    public void setPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }


    //ȭ���� ���ι������� ����
    public void setLandscapeLeft()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    //�ʱ�ȭ�� ����
    public void defaultSetting()
    {
        mainCanvas.SetActive(true);

        Player = Instantiate(Character);
        CameraManager.camManager.PlaneCam = false;
        stick = mainCanvas.transform.Find("JoyStickGroup").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        SceneSet = true;
        getInventory();
    }

    public void moveTownMap()
    {
        SceneSet = false;
        LoadingSceneManager.LoadScene("TownScene");
    }

    //Ÿ��� �̵��Ϸ��
    public void TownMapSceneMove()
    {
        mainCanvas.SetActive(true);

        Player = Instantiate(Character);
        CameraManager.camManager.PlaneCam = false;
        stick = mainCanvas.transform.Find("JoyStickGroup").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        SceneSet = true;
    }

    //�κ��丮 �ҷ�����
    public void getInventory()
    {
        StartCoroutine(FindAndActivateObject("Inventory", 1.0f));
    }

    //�Ĺָ� �̵�
    public void movePharmingMap()
    {
        SceneSet = false;
        LoadingSceneManager.LoadScene("PharmingScene");
    }

    //�Ĺָ� �̵��Ϸ��
    public void PharmingMapSceneMove()
    {
        mainCanvas.SetActive(true);

        Player = Instantiate(Character);
        CameraManager.camManager.PlaneCam = false;
        stick = mainCanvas.transform.Find("JoyStickGroup").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        SceneSet = true;
    }
    //������Ʈ ã�� �Լ�
    public IEnumerator FindAndActivateObject(string objectName, float delay)
    {
        yield return FindInactiveObjects.FindInactiveObjectByName(objectName, (foundObject) =>
        {  
            if (foundObject != null)
            {
                resultObject = foundObject;
                inventory = resultObject.GetComponent<Inventory>();
            }
            else
            {
                Debug.Log("not found : " + objectName);
            }
        }, delay);
    }

    //����ǥ�� �Լ�
    string FormatNumber(long number)
    {
        if(number >= 1_000_000_000)
        {
            return (number / 1_000_000_000f).ToString("0.##") + "c";
        }
        else if (number >= 1_000_000)
        {
            return (number / 1_000_000f).ToString("0.##") + "b";
        }
        else if (number >= 1_000)
        {
            return (number / 1_000f).ToString("0.##") + "a";
        }
        else
        {
            return number.ToString();
        }
    }

    public void UpdateNumberText()
    {
        //õ ������ ���ĺ� ��ȯ
        string formattedNumber = FormatNumber(PlayerCurrency);
        CurrencyText.text = formattedNumber;
        ShopMoneyText.text = formattedNumber;
    }

    //���� ���� ����
    public long Score01
    {
        get => PlayerCurrency;
        set
        {
            PlayerCurrency = value;
            UpdateNumberText();
        }
    }

    public void IncreaseMoney(long money)
    {
        Score01 += money;
    }

}
