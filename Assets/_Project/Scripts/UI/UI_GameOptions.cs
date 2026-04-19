using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_GameOptions : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private AudioMixer _audioMixer;
    [Header("Sliders")]
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _mouseSensitivitySlider;

    public event Action<float> OnSensitivityChanged;

    public void OnClickReturn() // Close the options panel
    {
        _optionsPanel.SetActive(false);
    }

    public void OnSlideMouseSensitivity(float sensitivity) // Change the sensitivity in the PlayerPrefs class
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        OnSensitivityChanged?.Invoke(sensitivity);
    }

    public void OnSlideSFXVolume(float value) // Update the volume for SFX
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("SFXVolume", volume);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }
        else
        {
            _audioMixer.SetFloat("SFXVolume", -80f);
            PlayerPrefs.SetFloat("SFXVolume", -80f);
        }
    }

    public void OnSlideMusicVolume(float value) // Update the volume for Music
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("MusicVolume", volume);
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }
        else
        {
            _audioMixer.SetFloat("MusicVolume", -80f);
            PlayerPrefs.SetFloat("MusicVolume", -80f);
        }
    }

    public void OnSlideMasterVolume(float value) // Update the volume for Master
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("MasterVolume", volume);
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
        else
        {
            _audioMixer.SetFloat("MasterVolume", -80f);
            PlayerPrefs.SetFloat("MasterVolume", -80f);
        }
    }

    private void OnEnable()
    {
        float volume = PlayerPrefs.GetFloat("MasterVolume");
        _masterVolumeSlider.value = Mathf.Pow(10, volume / 20);

        volume = PlayerPrefs.GetFloat("MusicVolume");
        _musicVolumeSlider.value = Mathf.Pow(10, volume / 20);

        volume = PlayerPrefs.GetFloat("SFXVolume");
        _sfxVolumeSlider.value = Mathf.Pow(10, volume / 20);

        float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 4f);
        _mouseSensitivitySlider.value = sensitivity;
    }

}
