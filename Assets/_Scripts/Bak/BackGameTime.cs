using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGameTime : MonoBehaviour {
    public float gameTime;
    GDATA data;
    public Text  timeGameText, deepMedText, deepAttText;
    public int seconds, minutes;
    public float deepMeditationTime, deepAttentionTime;
    // Use this for initialization
    void Start () {
        timeGameText.text = minutes + ":" + seconds;
        gameTime = 0;
        data = GDATA.Instance.GetComponent<GDATA>();
        data.ResetEEG();
    }
	
    public void ResetGame()
    {
        seconds = 30;
        minutes = 10;
        data.ResetEEG();
    }
	// Update is called once per frame
	void Update () {

    
            GameTime();
        DeepLevel();

    }

    void DeepLevel()
    {
        if (data.Meditation > 80)
            deepMeditationTime += Time.deltaTime;

        if (data.Attention > 80)
            deepAttentionTime += Time.deltaTime;
        deepMedText.text = "" + (int)deepMeditationTime + "s";
        deepAttText.text = "" + (int)deepAttentionTime + "s";

    }

    public void GameTime()
    {
        if (minutes < 0)
            timeGameText.text = 0 + ":0" + 0;
        else {
        gameTime += Time.deltaTime;
            if (gameTime >= 1.0f)
            {
                seconds--;
                gameTime -= 1.0f;
                if (seconds <= 0)
                {
                    seconds = 59;
                    minutes--;
                }
            }
            if (seconds < 10)
            {
                timeGameText.text = minutes + ":0" + seconds;
            }
            else
            {
                timeGameText.text = minutes + ":" + seconds;
            }

        }
    }
}
