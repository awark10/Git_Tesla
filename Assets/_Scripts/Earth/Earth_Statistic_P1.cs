using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Earth_Statistic_P1 : MonoBehaviour {

	GDATA data;
	public Earth_Game earthGame;

	public float avgMeditation, avgAttention;
	public float deepMeditationTime, deepAttentionTime;
	public float ballsVal;
    public Text avgMedText, avgAttText, deepAttText, deepMedText, gpText, descriptionGameText;

    private void Start()
    {
		data = GDATA.Instance.GetComponent<GDATA>();

        descriptionGameText.text = "текст описани для игр, условий уровней и тд";
    }

    void Update () 
	{		
		if (data.Attention > 0 && data.Meditation > 0) 
		{
			AvgLevel();
			DeepLevel ();
			Balls();
		}		
	}

	void AvgLevel()
	{
		avgMeditation = ( avgMeditation + data.Meditation ) / 2;
		avgAttention  = ( avgAttention + data.Attention ) / 2;
        avgMedText.text = "" + avgMeditation;
        avgAttText.text = "" + avgAttention;
    }

	void DeepLevel ()
	{
		if (data.Meditation > 80)
			deepMeditationTime += Time.deltaTime;
      
		if (data.Attention > 80)
			deepAttentionTime += Time.deltaTime;
        deepMedText.text = "" + (int)deepMeditationTime + " сек";
        deepAttText.text = "" + (int)deepAttentionTime + " сек";

    }

	void Balls()
	{
		ballsVal = (avgMeditation + avgAttention)*earthGame.gameLevel;
        gpText.text = "" + ballsVal;

    }
}