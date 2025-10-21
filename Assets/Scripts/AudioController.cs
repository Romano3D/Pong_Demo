using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // evita duplicação
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music && musicSource.isPlaying) return; // evita tocar de novo o mesmo som
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }
}
