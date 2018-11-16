using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Earth_Statistic_P1 : MonoBehaviour {

	int Meditation, Attention;

	public float attQual, medQual;
	public int attAvg,  medAvg;

	public int medMinutes, medSeconds;
	public int attMinutes, attSeconds;
	public int gameMinutes, gameSeconds;
	public float msecs = 0;

	public int ballsVal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if (GDATA.Instance.Attention > 0 && GDATA.Instance.Meditation > 0) 
		{
			Attention = GDATA.Instance.Attention;
			Meditation = GDATA.Instance.Meditation;
			AvgTime();
			Quality();
		}		
	}

	void Quality()
	{
		float totalTime = gameMinutes * 60 + gameSeconds;
		float medTime   = medMinutes * 60 + medSeconds;
		float attTime   = attMinutes * 60 + attSeconds;

		attQual = (attTime / totalTime) * 100;
		medQual = (medTime / totalTime) * 100;
	}

	void AvgTime()
	{
		msecs += Time.deltaTime;

		if (msecs >= 1.0f)
		{
			msecs = 0;
			gameSeconds++;

			if (gameSeconds > 59)
			{
				gameSeconds = 0;
				gameMinutes++;
			}

			if (Meditation > 50) {

				medSeconds++;

				if (medSeconds > 59) {
					medMinutes++;
					medSeconds = 0;
				}
			}

			if (Attention > 50) {
			
				attSeconds++;

				if (attSeconds > 59) {
					attMinutes++;
					attSeconds = 0;
				}
			}

			balls ();
		}			
	}


	void balls(){

		if (Meditation > 50 && Attention > 50)
			ballsVal += 1;
		if (Meditation > 60 && Attention > 60)
			ballsVal += 2;
		if (Meditation > 70 && Attention > 70)
			ballsVal += 3;
		if (Meditation > 80 && Attention > 80)
			ballsVal += 5;
	}

}