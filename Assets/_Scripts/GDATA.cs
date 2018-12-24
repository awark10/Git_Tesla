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
	// EEG DATA END

	// EEG DATA
	[Range(0, 100)]
	public int Attention, Meditation, Delta, Theta, LowAlpha, HighAlpha, LowBeta, HighBeta, LowGamma, HighGamma;
	public float maxAttention, maxMeditation, maxDelta, maxTheta, maxLowAlpha, maxHighAlpha, maxLowBeta, maxHighBeta, maxLowGamma, maxHighGamma;
	public float avgAttention, avgMeditation, avgDelta, avgTheta, avgLowAlpha, avgHighAlpha, avgLowBeta, avgHighBeta, avgLowGamma, avgHighGamma;
	public bool isNewAttention, isNewMeditation, isNewDelta, isNewTheta, isNewLowAlpha, isNewHighAlpha, isNewLowBeta, isNewHighBeta, isNewLowGamma, isNewHighGamma;
	// EEG DATA END

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
			= isNewLowBeta = isNewHighBeta = isNewLowGamma = isNewHighGamma = false;
    }

	void OnUpdateAttention(int value)
	{ 
		isNewAttention = true;
		maxAttention = maxReturn (maxAttention, value);
		avgAttention = filterSmooth (avgAttention, value);
		Attention = value;
	}
	void OnUpdateMeditation(int value)
	{
		isNewMeditation = true;
		maxMeditation = maxReturn (maxMeditation, value);
		avgMeditation = filterSmooth (avgMeditation, value);
		Meditation = value;
	}

	void OnUpdateDelta(float value)
	{
		isNewDelta = true;
		maxDelta = maxReturn (maxDelta, value);
		Delta = normalize (maxDelta, value);
		avgDelta = filterSmooth (avgDelta, Delta);
	}
	public bool getIsNewDelta ()
	{
		if (isNewDelta == true) 
		{
			isNewDelta = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateTheta(float value)
	{
		isNewTheta = true;
		maxTheta = maxReturn (maxTheta, value);
		Theta = normalize (maxTheta, value);
		avgTheta = filterSmooth (avgTheta, Theta);	
	}
	public bool getIsNewTheta ()
	{
		if (isNewTheta == true) 
		{
			isNewTheta = false;
			return true;
		} else 
			return false;
	}
		
	void OnUpdateHighAlpha(float value)
	{
		isNewHighAlpha = true;
		maxHighAlpha = maxReturn (maxHighAlpha, value);
		HighAlpha = normalize (maxHighAlpha, value);
		avgHighAlpha = filterSmooth (avgHighAlpha, HighAlpha);	
	}
	public bool getIsNewHighAlpha ()
	{
		if (isNewHighAlpha == true) 
		{
			isNewHighAlpha = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateHighBeta(float value)
	{
		isNewHighBeta = true;
		maxHighBeta = maxReturn (maxHighBeta, value);
		HighBeta = normalize (maxHighBeta, value);
		avgHighBeta = filterSmooth (avgHighBeta, HighBeta);	
	}
	public bool getIsNewHighBeta ()
	{
		if (isNewHighBeta == true) 
		{
			isNewHighBeta = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateHighGamma(float value)
	{
		isNewHighGamma = true;
		maxHighGamma = maxReturn (maxHighGamma, value);
		HighGamma = normalize (maxHighGamma, value);
		avgHighGamma = filterSmooth (avgHighGamma, HighGamma);	
	}
	public bool getIsNewHighGamma ()
	{
		if (isNewHighGamma == true) 
		{
			isNewHighGamma = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowAlpha(float value)
	{
		isNewLowAlpha = true;
		maxLowAlpha = maxReturn (maxLowAlpha, value);
		LowAlpha = normalize (maxLowAlpha, value);
		avgLowAlpha = filterSmooth (avgLowAlpha, LowAlpha);
	}
	public bool getIsNewLowAlpha ()
	{
		if (isNewLowAlpha == true) 
		{
			isNewLowAlpha = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowBeta(float value)
	{
		isNewLowBeta = true;
		maxLowBeta = maxReturn (maxLowBeta, value);
		LowBeta = normalize (maxLowBeta, value);
		avgLowBeta = filterSmooth (avgLowBeta, LowBeta);
	}
	public bool getIsNewLowBeta ()
	{
		if (isNewLowBeta == true) 
		{
			isNewLowBeta = false;
			return true;
		} else 
			return false;
	}

	void OnUpdateLowGamma(float value)
	{
		isNewLowGamma = true;
		maxLowGamma = maxReturn (maxLowGamma, value);
		LowGamma = normalize (maxLowGamma, value);
		avgLowGamma = filterSmooth (avgLowGamma, LowGamma);
	}
	public bool getIsNewLowGamma ()
	{
		if (isNewLowGamma == true) 
		{
			isNewLowGamma = false;
			return true;
		} else 
			return false;
	}		

	float maxReturn (float val1, float val2)
	{
		if (val2 > val1) return val2;
		else return val1;
	}

	float filterSmooth(float n_1, float n)
	{
		float val, k = 0.01f;
		val = n * k + (1 - k) * n_1;
		return val;
	}

	int normalize(float val1, float val2)
	{
		return (int)(( val2 * 100 ) / val1);
	}

    public void ResetEEG()
    {
        maxDelta = maxTheta = maxLowAlpha = maxHighAlpha = maxLowBeta = maxHighBeta = maxLowGamma = maxHighGamma = 0;
        avgDelta = avgTheta = avgLowAlpha = avgHighAlpha = avgLowBeta = avgHighBeta = avgLowGamma = avgHighGamma = 0;
    }
}
