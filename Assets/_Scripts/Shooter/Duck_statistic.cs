using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Duck_statistic : MonoBehaviour {

    GDATA data;
    //public Duck_game duck_Game;

    public float avgMeditation, avgAttention;
    public float deepMeditationTime, deepAttentionTime;
    public float ballsVal;
    public float gameTime;
    public Text gpText, timeGameText, avgMedText, deepMedText, avgAttText, deepAttText,  descriptionGameText;
    public int seconds, minutes, hours;

    private void Start()
    {
        data = GDATA.Instance.GetComponent<GDATA>();
        gpText.text = "0";
        timeGameText.text = "0:00";
        gameTime = 0;
        descriptionGameText.text = "текст описания для игр, условий уровней и тд";
    }

    void Update()
    {
        if (data.Attention > 0 && data.Meditation > 0)
        {
            AvgLevel();
            DeepLevel();
            GameTime();
           // Balls();
        }
    }
    
    public void GameTime()
    {
        gameTime += Time.deltaTime;
        if (gameTime>=1.0f)
        {
            seconds++;
            gameTime -= 1.0f;
            if(seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes > 60)
                {
                    minutes = 0;
                    hours++;
                    if (hours >= 24)
                    {
                        hours = 0;
                    }
                }
            }
        }


        if (seconds < 10)
        {
            timeGameText.text = minutes+":0" +seconds;
        }
        else
        {
            timeGameText.text = minutes+":" + seconds;
        }
    }

    void AvgLevel()
    {
        //avgMeditation = (avgMeditation + data.Meditation) / 2;
        //avgAttention = (avgAttention + data.Attention) / 2;
        avgMedText.text = "" + (int)data.avgMeditation;
        avgAttText.text = "" + (int)data.avgAttention;
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

  public  void Balls(int coeficient)
    {
            ballsVal += ((int)avgAttention+ (int)avgMeditation) * coeficient;
        gpText.text = "" + ballsVal;
    }
}
