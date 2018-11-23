using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using System.IO;

public class Sound_controller : MonoBehaviour {

    public Sprite enableSprite;
    public Sprite disableSprite;
    public int sound;
    public static bool audioEnabled;
    public bool AudioEnabled { get { return audioEnabled; } set { SetAudio(value); } }

    Image image;
    public  Image imageBack;

    void Start()
    {
        image = GetComponent<Image>();
        if (PlayerPrefs.HasKey("savesound"))
        {
            sound = PlayerPrefs.GetInt("savesound");
        }
        else
        {
            PlayerPrefs.SetInt("savesound", 1);
            PlayerPrefs.Save();
        }


        if (sound == 1)
        {
            audioEnabled = true;
            SetAudio(audioEnabled);
            Debug.Log("Sound ON");
        }
        else
        {
            audioEnabled = false;
            SetAudio(audioEnabled);
            image.sprite = enableSprite;
            Debug.Log("Sound OFF");

        }
    }

    void SetAudio(bool enabled)
    {
        if (enabled)
        {
            AudioListener.volume = 1f;
            image.sprite = disableSprite;
            imageBack.color = Color.grey;
            sound = 1;
            PlayerPrefs.SetInt("savesound", sound);
            PlayerPrefs.Save();
        }
        else
        {
            AudioListener.volume = 0f;
            image.sprite = enableSprite;
            imageBack.color = Color.green;
            sound = 0;
            PlayerPrefs.SetInt("savesound", sound);
            PlayerPrefs.Save();
        }
        audioEnabled = enabled;
    }

    public void SwitchAudio()
    {
        AudioEnabled = !AudioEnabled;
    }
}
