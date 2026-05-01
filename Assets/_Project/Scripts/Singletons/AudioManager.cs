using UnityEngine;

public class AudioManager : GenericSingleton<AudioManager>
{
    [Header("Music clips")]
    [SerializeField] private AudioClip[] _bgms;
    [Header("Sound effects")]
    [SerializeField] private AudioClip[] _zombieEnemySounds;
    [SerializeField] private AudioClip[] _propsSounds;

    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();

        _audioSource = GetComponent<AudioSource>();
    }

    public AudioClip GetMusicClip(string sceneName)
    {
        foreach (var clip in _bgms)
        {
            if (clip.name == sceneName + "MusicClip")
                return clip;
        }

        Debug.LogWarning($"ERROR: No music found for the scene {sceneName}");
        return null;
    }

    public void PlayMusic(string sceneName)
    {
        AudioClip music = AudioManager.Instance.GetMusicClip(sceneName);

        if (music != null)
        {
            _audioSource.Stop();
            _audioSource.clip = music;
            _audioSource.Play();
        }
    }
}
