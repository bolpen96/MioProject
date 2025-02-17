using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class BtnManager : MonoBehaviour
{
    //��ư ����
    public GameObject MenuGroup;
    public GameObject SettingView;

    //���Ǽ��� ����
    public GameObject musicManager;
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public Toggle T_Alert;

    //�޴�Ŭ��
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

    //���� ��Ʈ��
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

    //���۹� �ʵ� ���� �̺�Ʈ
    public void PlaneCreate()
    {
        /*
        //���� ���õǾ��ִ� ������Ʈ ����
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
