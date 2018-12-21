using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStatistic : MonoBehaviour {

    public ClockGame clockGame;

    public int avgMeditation, avgAttention;
    public float deepMeditationTime, deepAttentionTime;
    public int ballsVal;
    public Text avgMedText, avgAttText, deepAttText, deepMedText, gpText, descriptionGameText;

    private void Start()
    {
        descriptionGameText.text = "текст описани для игр, условий уровней и тд";
    }

    void Update()
    {
        if (CONNECTOR.Instance.Attention > 0 && CONNECTOR.Instance.Meditation > 0)
        {
            AvgLevel();
            DeepLevel();
            Balls();
        }
    }

    void AvgLevel()
    {
        avgMeditation = (avgMeditation + CONNECTOR.Instance.Meditation) / 2;
        avgAttention = (avgAttention + CONNECTOR.Instance.Attention) / 2;
        avgMedText.text = "" + avgMeditation;
        avgAttText.text = "" + avgAttention;
    }

    void DeepLevel()
    {
        if (CONNECTOR.Instance.Meditation > 80)
            deepMeditationTime += Time.deltaTime;

        if (CONNECTOR.Instance.Attention > 80)
            deepAttentionTime += Time.deltaTime;
        deepMedText.text = "" + (int)deepMeditationTime + " сек";
        deepAttText.text = "" + (int)deepAttentionTime + " сек";

    }

    void Balls()
    {
        ballsVal = (avgMeditation + avgAttention);
        gpText.text = "" + ballsVal;

    }
}
