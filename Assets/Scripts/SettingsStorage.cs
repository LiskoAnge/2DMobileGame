using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsStorage : MonoBehaviour
{
    public static SettingsStorage instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    //add here possible dyslexic font region

    #region Audio

    public bool enableSound;

    public void SoundEnabled()
    {
        enableSound = true;
    }
    public void DisableSound()
    {
        enableSound = false;
    }

    #endregion
}
