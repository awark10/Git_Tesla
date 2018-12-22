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
	// EEG DATA END

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(35, 125, Screen.width - 25, Screen.height - 25));
		GUILayout.BeginVertical();
		GUILayout.Label("maxDelta:" + maxDelta);
		GUILayout.Label("avgDelta:" + avgDelta);
		GUILayout.Label("Delta:" + Delta);
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}

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
    }

	void OnUpdateAttention(int value)
	{ 
		maxAttention = maxReturn (maxAttention, value);
		Attention = value;
		avgAttention = filterSmooth (avgAttention, Attention);
	}
	void OnUpdateMeditation(int value)
	{
		maxMeditation = maxReturn (maxMeditation, value);
		Meditation = value;
		avgMeditation = filterSmooth (avgMeditation, Meditation);
	}
	void OnUpdateDelta(float value)
	{
		maxDelta = maxReturn (maxDelta, value);
		Delta = normalize (maxDelta, value);
		avgDelta = filterSmooth (avgDelta, Delta);
	}
	void OnUpdateTheta(float value)
	{
		maxTheta = maxReturn (maxTheta, value);
		Theta = normalize (maxTheta, value);
		avgTheta = filterSmooth (avgTheta, Theta);	
	}
	void OnUpdateHighAlpha(float value)
	{
		maxHighAlpha = maxReturn (maxHighAlpha, value);
		HighAlpha = normalize (maxHighAlpha, value);
		avgHighAlpha = filterSmooth (avgHighAlpha, HighAlpha);	
	}
	void OnUpdateHighBeta(float value)
	{
		maxHighBeta = maxReturn (maxHighBeta, value);
		HighBeta = normalize (maxHighBeta, value);
		avgHighBeta = filterSmooth (avgHighBeta, HighBeta);	
	}
	void OnUpdateHighGamma(float value)
	{
		maxHighGamma = maxReturn (maxHighGamma, value);
		HighGamma = normalize (maxHighGamma, value);
		avgHighGamma = filterSmooth (avgHighGamma, HighGamma);	
	}
	void OnUpdateLowAlpha(float value)
	{
		maxLowAlpha = maxReturn (maxLowAlpha, value);
		LowAlpha = normalize (maxLowAlpha, value);
		avgLowAlpha = filterSmooth (avgLowAlpha, LowAlpha);
	}
	void OnUpdateLowBeta(float value)
	{
		maxLowBeta = maxReturn (maxLowBeta, value);
		LowBeta = normalize (maxLowBeta, value);
		avgLowBeta = filterSmooth (avgLowBeta, LowBeta);
	}
	void OnUpdateLowGamma(float value)
	{
		maxLowGamma = maxReturn (maxLowGamma, value);
		LowGamma = normalize (maxLowGamma, value);
		avgLowGamma = filterSmooth (avgLowGamma, LowGamma);
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















}
