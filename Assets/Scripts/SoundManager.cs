using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundBtn;
    public AudioSource astExplosion;
    public AudioSource pExplosion;
    public AudioSource bulletSound;

    private SettingsStorage settings;

    private void Start()
    {
        settings = FindObjectOfType<SettingsStorage>();
    }

    public void PlaySoundButton()
    {
        if (settings.enableSound == true)
        {
            soundBtn.Play();
        }
    }

    public void AsteroidExplosion()
    {
        if (settings.enableSound == true && !astExplosion.isPlaying)
        {
            astExplosion.Play();
        }
    }


    public void PlayerExplosion()
    {
        if (settings.enableSound == true && !pExplosion.isPlaying)
        {
            pExplosion.Play();
        }
    }

    public void BulletSound()
    {
        if (settings.enableSound == true)
        {
            bulletSound.Play();
        }
    }
}