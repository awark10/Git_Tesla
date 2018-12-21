using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Earth_Statistic_P1 : MonoBehaviour {

	public int avgMeditation, avgAttention;
	public float deepMeditationTime, deepAttentionTime;
	public int ballsVal;
	
	// Update is called once per frame
	void Update () 
	{		
		if (CONNECTOR.Instance.Attention > 0 && CONNECTOR.Instance.Meditation > 0) 
		{
			AvgLevel();
			DeepLevel ();
			balls();
		}		
	}

	void AvgLevel()
	{
		avgMeditation = ( avgMeditation + CONNECTOR.Instance.Meditation ) / 2;
		avgAttention  = ( avgAttention + CONNECTOR.Instance.Attention ) / 2;
	}

	void DeepLevel ()
	{
		if (CONNECTOR.Instance.Meditation > 80)
			deepMeditationTime += Time.deltaTime;
		if (CONNECTOR.Instance.Attention > 80)
			deepAttentionTime += Time.deltaTime;
	}

	void balls()
	{

	}
}