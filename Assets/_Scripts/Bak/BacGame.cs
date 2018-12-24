using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BacGame : MonoBehaviour {

	GDATA data;

	public BacController bacDelta, bacTheta, bacAlphaH, bacAplhaL, bacBetaH, bacBetaL, bacGammaH, bacGammaL;

    public Text avgMedText, avgAttText;
    public Slider sliderMed, sliderAtt;

	int [] ladLevel = {0,15,30,45,60,75,90,100};
	float [,] DeltaSoundArray = { {0f,10f}, {11.2f,20f}, {21.4f,31f}, {33.6f,45f}, {47.3f,59f}, {60.8f,73f}, {74.8f,84f} };
	float [,] ThetaSoundArray = { {1f,6f}, {7.5f,13f}, {14.5f,18f}, {19.2f,24f}, {24.7f,30f}, {31.6f,36f}, {37.6f,42.6f} };
	float [,] AlphaHSoundArray = { {0f,4.2f}, {4.5f,11.3f}, {11.7f,18.9f}, {19.4f,26.5f}, {27.2f,31.6f}, {31.9f,37.2f}, {37.7f,43.2f} };
	float [,] AlphaLSoundArray = { {2.3f,6.3f}, {6.7f,10.6f}, {11.3f,15.4f}, {16.3f,21.0f}, {22.0f,26.0f}, {29.4f,33.0f}, {35.0f,40.0f} };
	float [,] BetaHSoundArray = { {1.5f,67.0f}, {12.5f,67.0f}, {21.3f,67.0f}, {29.2f,67.0f}, {37.9f,67.0f}, {45.9f,67.0f}, {53.9f,67.0f} };
	float [,] BetaLSoundArray = { {1.4f,42.0f}, {7.0f,42.0f}, {13.2f,42.0f}, {19.2f,42.0f}, {25.1f,42.0f}, {30.1f,42.0f}, {36.1f,42.0f} };
	float [,] GammaLSoundArray = { {9.5f,160.0f}, {21.4f,160.2f}, {30.8f,160.2f}, {39.0f,160.3f}, {50.0f,160.0f}, {78.5f,160.0f}, {94.6f,160.0f} };
	float [,] GammaHSoundArray = { {30.0f,480.0f}, {51.0f,480.2f}, {74.0f,480.2f}, {110.0f,480.3f}, {260.0f,480.0f}, {280.5f,480.0f}, {305.6f,480.0f} };

	void Start () {

		data = GDATA.Instance.GetComponent<GDATA>();
	}
	
	void FixedUpdate () 
	{
		gameLogic ();
		UIupdate ();
	}
    void OnEnable()
    {
       // data.ResetEEG();
    }

    void gameLogic ()
	{
		if (data.isNewAttention) 
		{


			data.isNewAttention = false;
		}

		if (data.isNewMeditation) 
		{

			data.isNewMeditation = false;
		}

		if (data.getIsNewDelta()) 
			bacDelta.play (data.Delta, data.avgDelta, ladLevel, DeltaSoundArray);

		if (data.getIsNewTheta()) 
			bacTheta.play (data.Theta, data.avgTheta, ladLevel, ThetaSoundArray);

		if (data.getIsNewHighAlpha()) 
			bacAlphaH.play (data.HighAlpha, data.avgHighAlpha, ladLevel, AlphaHSoundArray);

		if (data.getIsNewLowAlpha()) 
			bacAplhaL.play (data.LowAlpha, data.avgLowAlpha, ladLevel, AlphaHSoundArray);

		if (data.getIsNewHighBeta()) 
			bacBetaH.play (data.HighBeta, data.avgHighBeta, ladLevel, BetaHSoundArray);

		if (data.getIsNewLowBeta()) 
			bacBetaL.play (data.LowBeta, data.avgLowBeta, ladLevel, BetaLSoundArray);

		if (data.getIsNewLowGamma()) 
			bacGammaL.play (data.LowGamma, data.avgLowGamma, ladLevel, GammaLSoundArray);

		if (data.getIsNewHighGamma()) 
			bacGammaH.play (data.HighGamma, data.avgHighGamma, ladLevel, GammaHSoundArray);
	}

	void UIupdate()
	{
        avgMedText.text =""+ data.avgMeditation;
        sliderMed.value = data.Meditation;

        avgAttText.text = "" + data.avgAttention;
        sliderAtt.value = data.Attention;
    }
}
