using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDATA : MonoBehaviour {

	public static GDATA Instance { get; set;}
	ThinkGearController controller;
	   
	// USER DATA
	public string userName = "Petro";
	public int userAge = 29;
    // USER DATA END

    // EEG DATA
    [Range(0, 100)]
	public float AttentionRaw, MeditationRaw, DeltaRaw, ThetaRaw, LowAlphaRaw, HighAlphaRaw, LowBetaRaw, HighBetaRaw, LowGammaRaw, HighGammaRaw;
	public int Attention, Meditation, Delta, Theta, LowAlpha, HighAlpha, LowBeta, HighBeta, LowGamma, HighGamma;
	public float avgAttention, avgMeditation, avgDelta, avgTheta, avgLowAlpha, avgHighAlpha, avgLowBeta, avgHighBeta, avgLowGamma, avgHighGamma;

	public bool isReadyToShow = false;
	public int  isNewAttention, isNewMeditation, isNewDelta, isNewTheta, isNewLowAlpha, isNewHighAlpha, isNewLowBeta, isNewHighBeta, isNewLowGamma, isNewHighGamma;
	// EEG DATA END

	private int [,] dataMass = new int [10, 10000];
	private int indexMass = 0;


	public int deepAttentionTime, deepMeditationTime;

	void Awake ()
	{
		if (Instance == null) 
		{
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else 
		{
			Destroy (gameObject);
		}
    }
		
    void Start () 
	{  
		controller = ThinkGearController.Instance.GetComponent<ThinkGearController>();

		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdateDeltaEvent += OnUpdateDelta;
		controller.UpdateThetaEvent += OnUpdateTheta;
		controller.UpdateHighAlphaEvent += OnUpdateHighAlpha;
		controller.UpdateHighBetaEvent += OnUpdateHighBeta;
		controller.UpdateHighGammaEvent += OnUpdateHighGamma;
		controller.UpdateLowAlphaEvent += OnUpdateLowAlpha;
		controller.UpdateLowBetaEvent += OnUpdateLowBeta;
		controller.UpdateLowGammaEvent += OnUpdateLowGamma;

		isNewDelta = isNewTheta = isNewLowAlpha = isNewHighAlpha
			= isNewLowBeta = isNewHighBeta = isNewLowGamma = isNewHighGamma = 0;
		
		isNewAttention = isNewMeditation = 0;

		isReadyToShow = false;
		indexMass = 0;
    }

	public void normalize()
	{
		if (isNewDelta == 1 && isNewTheta == 1 && isNewLowAlpha == 1 && isNewHighAlpha == 1 &&
		   isNewLowBeta == 1 && isNewHighBeta == 1 && isNewLowGamma == 1 && isNewHighGamma == 1
			&& isNewAttention == 1 && isNewMeditation == 1 && indexMass <= 9999) 
		{

			float sumRaw = DeltaRaw + ThetaRaw + LowAlphaRaw + HighAlphaRaw + LowBetaRaw + HighBetaRaw + LowGammaRaw + HighGammaRaw;

			Delta     = (int) ( DeltaRaw * 100 / sumRaw );
			Theta     = (int) ( ThetaRaw * 100 / sumRaw );
			LowAlpha  = (int) ( LowAlphaRaw * 100 / sumRaw );
			HighAlpha = (int) ( HighAlphaRaw * 100 / sumRaw );
			LowBeta   = (int) ( LowBetaRaw * 100 / sumRaw );
			HighBeta  = (int) ( HighBetaRaw * 100 / sumRaw );
			LowGamma  = (int) ( LowGammaRaw * 100 / sumRaw );
			HighGamma = (int) ( HighGammaRaw * 100 / sumRaw );
			Attention = (int) AttentionRaw;
			Meditation = (int) MeditationRaw;

			dataMass [0, indexMass] = Delta;
			dataMass [1, indexMass] = Theta;
			dataMass [2, indexMass] = LowAlpha;
			dataMass [3, indexMass] = HighAlpha;
			dataMass [4, indexMass] = LowBeta;
			dataMass [5, indexMass] = HighBeta;
			dataMass [6, indexMass] = LowGamma;
			dataMass [7, indexMass] = HighGamma;
			dataMass [8, indexMass] = (int) AttentionRaw;
			dataMass [9, indexMass] = (int) MeditationRaw;

			for (int i = 0; i <= indexMass; i++)
				avgDelta += dataMass [0, i];
			avgDelta = avgDelta / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgTheta += dataMass [1, i];
			avgTheta = avgTheta / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgLowAlpha += dataMass [2, i];
			avgLowAlpha = avgLowAlpha / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgHighAlpha += dataMass [3, i];
			avgHighAlpha = avgHighAlpha / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgLowBeta += dataMass [4, i];
			avgLowBeta = avgLowBeta / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgHighBeta += dataMass [5, i];
			avgHighBeta = avgHighBeta / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgLowGamma += dataMass [6, i];
			avgLowGamma = avgLowGamma / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgHighGamma += dataMass [7, i];
			avgHighGamma = avgHighGamma / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgAttention += dataMass [8, i];
			avgAttention = avgAttention / indexMass;

			for (int i = 0; i <= indexMass; i++)
				avgMeditation += dataMass [9, i];
			avgMeditation = avgMeditation / indexMass;

			isNewDelta = isNewTheta = isNewLowAlpha = isNewHighAlpha
				= isNewLowBeta = isNewHighBeta = isNewLowGamma = isNewHighGamma = 0;

			isNewAttention = isNewMeditation = 0;

			isReadyToShow = true;

			indexMass++;
		}
	}

	void OnUpdateDelta(float value)
	{
		DeltaRaw = value;
		isNewDelta = 1;
	}

	void OnUpdateTheta(float value)
	{
		ThetaRaw = value;
		isNewTheta = 1;
	}
		
	void OnUpdateHighAlpha(float value)
	{
		HighAlphaRaw = value;
		isNewHighAlpha = 1;
		normalize ();
	}

	void OnUpdateHighBeta(float value)
	{
		HighBetaRaw = value;
		isNewHighBeta = 1;
	}

	void OnUpdateHighGamma(float value)
	{
		HighGammaRaw = value;
		isNewHighGamma = 1;
	}

	void OnUpdateLowAlpha(float value)
	{
		LowAlphaRaw = value;
		isNewLowAlpha = 1;
	}

	void OnUpdateLowBeta(float value)
	{
		LowBetaRaw = value;
		isNewLowBeta = 1;
	}

	void OnUpdateLowGamma(float value)
	{
		LowGammaRaw = value;
		isNewLowGamma = 1;
	}

	void OnUpdateAttention(int value)
	{ 
		isNewAttention = 1;
		AttentionRaw = value;

		if (value > 80)
			deepAttentionTime++;
	}

	void OnUpdateMeditation(int value)
	{
		isNewMeditation = 1;
		MeditationRaw = value;

		if (value > 80)
			deepMeditationTime++;
	}

    public void ResetEEG()
    {
        avgDelta = avgTheta = avgLowAlpha = avgHighAlpha = avgLowBeta = avgHighBeta = avgLowGamma = avgHighGamma = 0;
		deepAttentionTime = deepMeditationTime = 0;
		avgAttention = avgMeditation = 0;
		indexMass = 0;
    }
}
