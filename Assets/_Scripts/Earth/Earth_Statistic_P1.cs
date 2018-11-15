using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Earth_Statistic_P1 : MonoBehaviour {

	public int statGameTimeSec=0;
	public float msecs = 0;
	public int statGameMin=0;
	public int statMedMinF = 0;
	public float statMedTime=0;
	public float statMed60Time = 0;
	public float statMed80Time = 0;
	public float statMed50Time = 0;
	public float statMed90TimeMin=0;
	public float statMed60TimeMin = 0;
	public float statMed50TimeMin = 0;

	int Meditation, Attention;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Meditation > 0 && Attention > 0) 
		{
			Attention = GDATA.Instance.Attention;
			Meditation = GDATA.Instance.Meditation;
			StatProccesing ();
		}		

	}

	public void StatProccesing()
	{
		msecs += Time.deltaTime;
		if (msecs >= 1.0f)
		{
			msecs -= 0;
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
			if (statMedTime >= 60)
			{
				statMedTime = 0;
				statMedMinF++;
			}

			if (Meditation >= 90) { 
				statMed80Time += Time.deltaTime;
				if (statMed80Time >= 60)
				{
					statMed80Time = 0;
					statMed90TimeMin++;
				}
			}
			if (Meditation >= 60) { 
				statMed60Time += Time.deltaTime;
				if (statMed60Time >= 60)
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
		}
	}



	void OnUpdateAttention(int value)
	{ 
		Attention = value;
	}
	void OnUpdateMeditation(int value)
	{
		Meditation = value;
		// statistic part
		//if(value>0)
			//statMedLevel = (statMedLevel + value) / 2;
	}
}