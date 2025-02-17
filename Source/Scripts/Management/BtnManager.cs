using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class BtnManager : MonoBehaviour
{
    //버튼 관련
    public GameObject MenuGroup;
    public GameObject SettingView;

    //음악설정 관련
    public GameObject musicManager;
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public Toggle T_Alert;

    //메뉴클릭
    public void MenuClick()
    {
        if (MenuGroup.activeSelf == false)
        {
            MenuGroup.SetActive(true);
        }
        else
        {
            MenuGroup.SetActive(false);
        }
    }

    public void SettingClick()
    {
        if(SettingView.activeSelf == false)
        {
            SettingView.SetActive(true);
        }
        else
        {
            SettingView.SetActive(false);
        }
    }

    //음악 컨트롤
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    //농작물 필드 생성 이벤트
    public void PlaneCreate()
    {
        /*
        //현재 선택되어있는 오브젝트 제거
        GameManager.instance.TouchPos = null; 
        */

        if (CameraManager.camManager.PlaneCam == false)
        {            
            GameManager.instance.Player = Instantiate(GameManager.instance.TouchPos);
            CameraManager.camManager.PlaneCam = true;
        }
        else if (CameraManager.camManager.PlaneCam == true)
        {
            GameManager.instance.Player = GameManager.instance.Character;
            CameraManager.camManager.PlaneCam = false;
        }

    }

    public void SwichAlert()
    {
        GameManager.instance.OnAlert = T_Alert.isOn;
    }

}
