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

    //숫자표식 함수
    public TextMeshProUGUI CurrencyText;
    public TextMeshProUGUI ShopMoneyText;
    public TextMeshProUGUI ShopMoneyCashText;

    public long PlayerCurrency;


    private void Awake()
    {
        instance = this;
        setLandscapeLeft();
        DontDestroyOnLoad(this);

        //초기설정
        OnAlert = true;
    }

    private void Start()
    {
        defaultSetting();
    }

    //화면을 세로방향으로 설정
    public void setPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }


    //화면을 가로방향으로 설정
    public void setLandscapeLeft()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    //초기화면 셋팅
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

    //타운맵 이동완료시
    public void TownMapSceneMove()
    {
        mainCanvas.SetActive(true);

        Player = Instantiate(Character);
        CameraManager.camManager.PlaneCam = false;
        stick = mainCanvas.transform.Find("JoyStickGroup").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        SceneSet = true;
    }

    //인벤토리 불러오기
    public void getInventory()
    {
        StartCoroutine(FindAndActivateObject("Inventory", 1.0f));
    }

    //파밍맵 이동
    public void movePharmingMap()
    {
        SceneSet = false;
        LoadingSceneManager.LoadScene("PharmingScene");
    }

    //파밍맵 이동완료시
    public void PharmingMapSceneMove()
    {
        mainCanvas.SetActive(true);

        Player = Instantiate(Character);
        CameraManager.camManager.PlaneCam = false;
        stick = mainCanvas.transform.Find("JoyStickGroup").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        SceneSet = true;
    }
    //오브젝트 찾는 함수
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

    //숫자표식 함수
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
        //천 단위로 알파벳 변환
        string formattedNumber = FormatNumber(PlayerCurrency);
        CurrencyText.text = formattedNumber;
        ShopMoneyText.text = formattedNumber;
    }

    //점수 변동 반응
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
