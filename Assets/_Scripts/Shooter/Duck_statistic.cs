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
    public Text avgMedText, avgAttText, deepAttText, deepMedText, gpText, descriptionGameText;

    private void Start()
    {
        data = GDATA.Instance.GetComponent<GDATA>();
        gpText.text = "0";
        descriptionGameText.text = "текст описани для игр, условий уровней и тд";
    }

    void Update()
    {
        if (data.Attention > 0 && data.Meditation > 0)
        {
            AvgLevel();
            DeepLevel();
           // Balls();
        }
    }

    void AvgLevel()
    {
        avgMeditation = (avgMeditation + data.Meditation) / 2;
        avgAttention = (avgAttention + data.Attention) / 2;
        avgMedText.text = "" + (int)avgMeditation;
        avgAttText.text = "" + (int)avgAttention;
    }

    void DeepLevel()
    {
        if (data.Meditation > 80)
            deepMeditationTime += Time.deltaTime;

        if (data.Attention > 80)
            deepAttentionTime += Time.deltaTime;
        deepMedText.text = "" + (int)deepMeditationTime + " сек";
        deepAttText.text = "" + (int)deepAttentionTime + " сек";

    }

  public  void Balls(int coeficient)
    {
            ballsVal += ((int)avgAttention+ (int)avgMeditation) * coeficient;
        gpText.text = "" + ballsVal;
    }
}
