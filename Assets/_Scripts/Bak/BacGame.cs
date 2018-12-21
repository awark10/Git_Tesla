using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacGame : MonoBehaviour {


	public float Attention, Meditation;
	public float avgAttention, avgMeditation;

	public float Delta = 0.0f;
	public float Theta = 0.0f;
	public float LowAlpha = 0.0f;
	public float HighAlpha = 0.0f;
	public float LowBeta = 0.0f;
	public float HighBeta = 0.0f;
	public float LowGamma = 0.0f;
	public float HighGamma = 0.0f;

	public float avgDelta = 0.0f;
	public float avgTheta = 0.0f;
	public float avgLowAlpha = 0.0f;
	public float avgHighAlpha = 0.0f;
	public float avgLowBeta = 0.0f;
	public float avgHighBeta = 0.0f;
	public float avgLowGamma = 0.0f;
	public float avgHighGamma = 0.0f;

	void Start () {
		
	}
	
	void Update () 
	{
		avgAttention = (Attention + CONNECTOR.Instance.Attention) / 2;
		Attention = CONNECTOR.Instance.Attention;

		avgMeditation = (Meditation +  CONNECTOR.Instance.Meditation) / 2;
		Meditation = CONNECTOR.Instance.Meditation;

		avgDelta = (Delta + CONNECTOR.Instance.Delta) / 2;
		Delta = CONNECTOR.Instance.Delta;
	
		avgTheta = (Theta + CONNECTOR.Instance.Theta) / 2;
		Theta = CONNECTOR.Instance.Theta;

		avgLowAlpha = (LowAlpha + CONNECTOR.Instance.LowAlpha) / 2;
		LowAlpha = CONNECTOR.Instance.LowAlpha;
		avgHighAlpha = (HighAlpha + CONNECTOR.Instance.HighAlpha) / 2;
		HighAlpha = CONNECTOR.Instance.HighAlpha;

		avgLowBeta = (LowBeta + CONNECTOR.Instance.LowBeta) / 2;
		LowBeta = CONNECTOR.Instance.LowBeta;
		avgHighBeta = (HighBeta + CONNECTOR.Instance.HighBeta) / 2;
		HighBeta = CONNECTOR.Instance.HighBeta;

		avgLowGamma = (LowGamma + CONNECTOR.Instance.LowGamma) / 2;
		LowGamma = CONNECTOR.Instance.LowGamma;
		avgHighGamma = (HighGamma + CONNECTOR.Instance.HighGamma) / 2;
		HighGamma = CONNECTOR.Instance.HighGamma;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//ShowPauseMenu();
		}

		collector ();
		UIupdate ();
	}

	void collector ()
	{
		
	}

	void UIupdate()
	{
		
	}
}
