using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundBtn;
    public AudioSource astExplosion1;
    public AudioSource astExplosion2;
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
        int randomSound = Random.Range(0, 1);

      
        if (settings.enableSound == true)
        {

            if (randomSound == 0 && !astExplosion1.isPlaying)
            {
                astExplosion1.Play();
            }
            else if (randomSound == 0 && !astExplosion2.isPlaying)
            {
                astExplosion2.Play();
            }
 
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