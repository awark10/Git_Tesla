using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStatistic : MonoBehaviour {

	ThinkGearController controller;
	public int Attention = 0;
	public int Meditation = 0;


	// Use this for initialization
	void Start () {

		controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	void OnUpdateAttention(int value)
	{
		Attention = value;
	}
	void OnUpdateMeditation(int value)
	{
		Meditation = value;
		// statistic part
		if(value>0)
			statMedLevel = (statMedLevel + value) / 2;
	}

	public int statGameTimeSec=0;
	public float msecs = 0;
	public int statGameMin=0;
	public int statMedMinF = 0;
	public float statMed90TimeMin=0;
	public float statMed60TimeMin = 0;
	public float statMed50TimeMin = 0;

	public void StatProccesing()
	{
		if (gameUI.activeSelf == true) { 
			if (Meditation > 0 && Attention > 0)
			{
				msecs += Time.deltaTime;
				if (msecs >= 1.0f)
				{
					msecs -= 1.0f;
					statGameTimeSec++;
					if (statGameTimeSec >=60)
					{
						statGameTimeSec = 0;
						statGameMin++;
					}
				}

				if (Meditation > Attention && Time.deltaTime != 0)
				{
					statMedTime += Time.deltaTime;
					if (statMedTime >= 60.0f)
					{
						statMedTime = 0;
						statMedMinF++;
					}

					if (Meditation >= 90) { 
						statMed80Time += Time.deltaTime;
						if (statMed80Time >= 60.0f)
						{
							statMed80Time = 0;
							statMed90TimeMin++;
						}
					}
					if (Meditation >= 60) { 
						statMed60Time += Time.deltaTime;
						if (statMed60Time >= 60.0f)
						{
							statMed60Time = 0;
							statMed60TimeMin++;
						}

					}
					/* if (Meditation >= 50) { 
                     statMed50Time += Time.deltaTime;
                         if (statMed50Time >= 60.0f)
                         {
                             statMed50Time = 0;
                             statMed50TimeMin++;
                         }
                     }*/
				//}
			//}
/*
			if (tmpStat == 1)
			{

				statGameTime = 0;
				statMedTime = 0;
				statMedLevel = 0;
				//  statMed50Time = 0;
				statMed60Time = 0;
				statMed80Time = 0;
				StopGame();
				tmpStat = 0;
			}

			statStr = "Game time - "+ statGameMin + ":"+ statGameTimeSec + "\r\n\r\n";
			statStr += "Meditation time - "+ statMedMinF + ":" + (int)statMedTime + "\r\n\r\n";
			statStr += "Meditate(avg) -  " + (int)statMedLevel + "\r\n\r\n";
			// statStr += "50 meditation - "+ statMed50TimeMin + ":" + (int)statMed50Time + "\r\n\r\n";
			statStr += "Meditate >60 - "+ statMed60TimeMin+ ":" + (int)statMed60Time + "\r\n\r\n";
			statStr += "Meditate >90 - " + statMed90TimeMin + ":"+ (int)statMed80Time;

			statText.text = statStr;
		}
	}
       */
}
