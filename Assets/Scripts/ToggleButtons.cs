using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    public Image soundToggle;
    private bool soundToggleOn;
    private bool soundOn;

    private void Start()
    {
        soundToggleOn = (PlayerPrefs.GetInt("soundToggle") == 1) ? true : false;
        soundOn = (PlayerPrefs.GetInt("soundToggle") == 1) ? true : false;

        if (soundToggleOn)
        {
            if (soundToggle != null)
            {
                soundToggle.rectTransform.anchoredPosition = new Vector2(45, 0);
                soundToggle.GetComponent<Image>().color = new Color32(0, 1, 159, 225);
            }
        }
        else if (soundToggleOn == false)
        {
            if (soundToggle != null)
            {
                soundToggle.rectTransform.anchoredPosition = new Vector2(-45, 0);
                soundToggle.GetComponent<Image>().color = new Color32(159, 27, 0, 225);
            }
        }
        if (soundOn)
        {
            SettingsStorage.instance.SoundEnabled();
        }
        else if (soundOn == false)
        {
            SettingsStorage.instance.DisableSound();
        }
    }

    public void OnSoundToggleClick()
    {
        soundToggleOn = !soundToggleOn;

        if (soundToggleOn)
        {
            SoundOn();
            soundToggle.GetComponent<Image>().color = new Color32(0, 1, 159, 225);
            soundToggle.rectTransform.anchoredPosition = new Vector2(45, 0);
            PlayerPrefs.SetInt("soundToggle", 1);
        }
        else
        {
            SoundOff();
            soundToggle.GetComponent<Image>().color = new Color32(159, 27, 0, 225);
            soundToggle.rectTransform.anchoredPosition = new Vector2(-45, 0);
            PlayerPrefs.SetInt("soundToggle", 0);
        }
    }

    public void SoundOn()
    {
        soundOn = true;
        SettingsStorage.instance.SoundEnabled();
        PlayerPrefs.SetInt("soundToggle", 1);
    }
    public void SoundOff()
    {
        soundOn = false;
        SettingsStorage.instance.DisableSound();
        PlayerPrefs.SetInt("soundToggle", 0);
    }

}