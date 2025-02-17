using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string EffectsVolumeKey = "EffectsVolume";

    private void Start()
    {
        //�����̴� �ʱⰪ ����
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);

        //�����̴� ���� ����� �� ȣ��� ������ �߰�
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);

        //�ҷ��� ���� ����� �ͼ��� ����
        SetMusicVolume(musicVolumeSlider.value);
        SetEffectsVolume(effectsVolumeSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        if(volume == 0)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(MusicVolumeKey, volume);
            PlayerPrefs.Save();
        }

    }

    public void SetEffectsVolume(float volume)
    {
        if (volume == 0)
        {
            audioMixer.SetFloat("EffectsVoulume", -80);
        }
        else
        {
            audioMixer.SetFloat("EffectsVoulume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(EffectsVolumeKey, volume);
            PlayerPrefs.Save();
        }
    }
}
