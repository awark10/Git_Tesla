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
	public int Attention, Meditation, Delta, Theta, LowAlpha, HighAlpha, LowBeta, HighBeta, LowGamma, HighGamma;
	public float DeltaRaw, ThetaRaw, LowAlphaRaw, HighAlphaRaw, LowBetaRaw, HighBetaRaw, LowGammaRaw, HighGammaRaw;
	public float avgAttention, avgMeditation, avgDelta, avgTheta, avgLowAlpha, avgHighAlpha, avgLowBeta, avgHighBeta, avgLowGamma, avgHighGamma;

	public int isNewAttention, isNewMeditation, isNewDelta, isNewTheta, isNewLowAlpha, isNewHighAlpha, isNewLowBeta, isNewHighBeta, isNewLowGamma, isNewHighGamma;
	// EEG DATA END

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

		isNewAttention = isNewMeditation = isNewDelta = isNewTheta = isNewLowAlpha = isNewHighAlpha
			= isNewLowBeta = isNewHighBeta = isNewLowGamma = isNewHighGamma = 0;
    }

	void normalize2()
	{
		if (isNewDelta == 1 && isNewTheta == 1 && isNewLowAlpha == 1 && isNewHighAlpha == 1 &&
		   isNewLowBeta == 1 && isNewHighBeta == 1 && isNewLowGamma == 1 && isNewHighGamma == 1) 
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

			avgDelta = filterSmooth (avgDelta, Delta);
			avgTheta = filterSmooth (avgTheta, Theta);	
			avgHighAlpha = filterSmooth (avgHighAlpha, HighAlpha);	
			avgHighBeta = filterSmooth (avgHighBeta, HighBeta);	
			avgHighGamma = filterSmooth (avgHighGamma, HighGamma);	
			avgLowAlpha = filterSmooth (avgLowAlpha, LowAlpha);
			avgLowBeta = filterSmooth (avgLowBeta, LowBeta);
			avgLowGamma = filterSmooth (avgLowGamma, LowGamma);

			isNewAttention = isNewMeditation = isNewDelta = isNewTheta = isNewLowAlpha = isNewHighAlpha
				= isNewLowBeta = isNewHighBeta = isNewLowGamma = isNewHighGamma = 2;
		}
	}

	void OnUpdateDelta(float value)
	{
		isNewDelta = 1;
		normalize2 ();
	}
	public bool getIsNewDelta ()
	{
		if (isNewDelta == 2) 
		{
			isNewDelta = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateTheta(float value)
	{
		isNewTheta = 1;
		normalize2 ();
	}
	public bool getIsNewTheta ()
	{
		if (isNewTheta == 2) 
		{
			isNewTheta = 0;
			return true;
		} else 
			return false;
	}
		
	void OnUpdateHighAlpha(float value)
	{
		isNewHighAlpha = 1;
		normalize2 ();
	}
	public bool getIsNewHighAlpha ()
	{
		if (isNewHighAlpha == 2) 
		{
			isNewHighAlpha = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateHighBeta(float value)
	{
		isNewHighBeta = 1;
		normalize2 ();
	}
	public bool getIsNewHighBeta ()
	{
		if (isNewHighBeta == 2) 
		{
			isNewHighBeta = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateHighGamma(float value)
	{
		isNewHighGamma = 1;
		normalize2 ();
	}
	public bool getIsNewHighGamma ()
	{
		if (isNewHighGamma == 2) 
		{
			isNewHighGamma = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowAlpha(float value)
	{
		isNewLowAlpha = 1;
		normalize2 ();
	}
	public bool getIsNewLowAlpha ()
	{
		if (isNewLowAlpha == 2) 
		{
			isNewLowAlpha = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowBeta(float value)
	{
		isNewLowBeta = 1;
		normalize2 ();
	}
	public bool getIsNewLowBeta ()
	{
		if (isNewLowBeta == 2) 
		{
			isNewLowBeta = 0;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowGamma(float value)
	{
		isNewLowGamma = 1;
		normalize2 ();
	}
	public bool getIsNewLowGamma ()
	{
		if (isNewLowGamma == 2) 
		{
			isNewLowGamma = 0;
			return true;
		} else 
			return false;
	}		

	void OnUpdateAttention(int value)
	{ 
		isNewAttention = 1;
		avgAttention = filterSmooth (avgAttention, value);
		Attention = value;

		if (value > 80)
			deepAttentionTime++;
	}
	void OnUpdateMeditation(int value)
	{
		isNewMeditation = 1;
		avgMeditation = filterSmooth (avgMeditation, value);
		Meditation = value;

		if (value > 80)
			deepMeditationTime++;
	}

	float maxReturn (float val1, float val2)
	{
		if (val2 > val1) 
			return val2;
		else 
			return val1;
	}

	float filterSmooth(float n_1, float n)
	{
		float val, k = 0.1f;
		val = n * k + (1 - k) * n_1;
		return val;
	}

	int normalize(float val1, float val2)
	{
		return (int)(( val2 * 100 ) / val1);
	}

    public void ResetEEG()
    {
        avgDelta = avgTheta = avgLowAlpha = avgHighAlpha = avgLowBeta = avgHighBeta = avgLowGamma = avgHighGamma = 0;
    }

	public void ResetUserData()
	{
		deepAttentionTime = deepMeditationTime = 0;
		avgAttention = avgMeditation = 0;
	}
}
