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
        //슬라이더 초기값 설정
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat(EffectsVolumeKey, 0.5f);

        //슬라이더 값이 변경될 때 호출될 리스너 추가
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsVolumeSlider.onValueChanged.AddListener(SetEffectsVolume);

        //불러온 값을 오디오 믹서에 적용
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
