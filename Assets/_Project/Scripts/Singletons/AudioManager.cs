using System;
using UnityEngine;

public class AudioManager : GenericSingleton<AudioManager>
{
    [Header("Music clips")]
    [SerializeField] private Sound[] _bgms;
    [Header("Sound effects")]
    [SerializeField] private Sound[] _sfxs;
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    public void PlayMusic(string sceneName)
    {
        Sound music = Array.Find(_bgms, x => x.Name == sceneName);

        if (music != null)
        {
            _musicSource.Stop();
            _musicSource.clip = music.Clip;
            _musicSource.Play();
        }

        else
        {
            Debug.LogWarning($"ERROR: No music found with name {sceneName}");
        }
    }

    public void PlaySFX(string sfx)
    {
        Sound sound = Array.Find(_sfxs, x => x.Name == sfx);

        if (sound != null)
        {
            _soundSource.PlayOneShot(sound.Clip);
        }

        else
        {
            Debug.LogWarning($"ERROR: No sound found with name {sfx}");
        }
    }
}
