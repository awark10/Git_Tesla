using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONNECTOR : MonoBehaviour {

	public static CONNECTOR Instance { get; set;}
	ThinkGearController controller;

	public bool isSignal = false;
	private float poorSignal=0;
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	public float Delta = 0.0f;
	public float Theta = 0.0f;
	public float LowAlpha = 0.0f;
	public float HighAlpha = 0.0f;
	public float LowBeta = 0.0f;
	public float HighBeta = 0.0f;
	public float LowGamma = 0.0f;
	public float HighGamma = 0.0f;

	private bool connectionStart = false;
	private int timeConnection = 0;
    
    public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	private float animationInterval = 0.06f;

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

		print ("CONNECTOR - Awake");
    }

	void Start () 
	{
		controller = ThinkGearController.Instance.GetComponent<ThinkGearController>();

		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
		controller.UpdateDeltaEvent += OnUpdateDelta;
		controller.UpdateThetaEvent += OnUpdateTheta;
		controller.UpdateHighAlphaEvent += OnUpdateHighAlpha;
		controller.UpdateHighBetaEvent += OnUpdateHighBeta;
		controller.UpdateHighGammaEvent += OnUpdateHighGamma;
		controller.UpdateLowAlphaEvent += OnUpdateLowAlpha;
		controller.UpdateLowBetaEvent += OnUpdateLowBeta;
		controller.UpdateLowGammaEvent += OnUpdateLowGamma;

		// Never Turn OFF Screen
		Screen.sleepTimeout = SleepTimeout.NeverSleep;  

		//Pre init variables
		Attention = 20;
		Meditation = 15;
	}

	public void OpenConnection()
	{
		if (!connectionStart)
		{
			timeConnection = 0;
			connectionStart = true;
			StartCoroutine(ConnectionFunc());	  

			UnityThinkGear.StartStream();
		}
    }

	IEnumerator ConnectionFunc()
	{
		while (true) 
		{
			timeConnection++;

            if (isSignal)
            {
				connectionStart = false;
				break;

			} 
			else if (timeConnection > 15) 
			{
				connectionStart = false;
				UnityThinkGear.StopStream();
				break;
			}
				
			yield return new WaitForSeconds (1f);
		}
	}
		
	void OnUpdateAttention(int value)
	{ 
		Attention = value;
	}

	void OnUpdateMeditation(int value)
	{
		Meditation = value;
	}

	void OnUpdateDelta(float value){
		Delta = value;
	}
	void OnUpdateTheta(float value){
		Theta = value;
	}
	void OnUpdateHighAlpha(float value){
		HighAlpha = value;
	}
	void OnUpdateHighBeta(float value){
		HighBeta = value;
	}
	void OnUpdateHighGamma(float value){
		HighGamma = value;
	}
	void OnUpdateLowAlpha(float value){
		LowAlpha = value;
	}
	void OnUpdateLowBeta(float value){
		LowBeta = value;
	}
	void OnUpdateLowGamma(float value){
		LowGamma = value;
	}

	void OnUpdatePoorSignal(int value)
	{      
		poorSignal = value;

		if (value == 200) //No connection
		{   
			isSignal = false;
		} 
		else if (value == 0)  // Stable connection
		{
			isSignal = true;
		} 
		else // Weak connection
		{
			isSignal = true;
		}

	}

	void FixedUpdate()
	{
		if (connectionStart)
		{
			if (indexSignalIcons >= 4.8)
			{
				indexSignalIcons = 2;
			}
			indexSignalIcons += animationInterval;
		}
        else if (isSignal == true)
            indexSignalIcons = 0;
        else if (isSignal == false)
            indexSignalIcons = 1;
    }

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width - 50, 25, Screen.width-25 , Screen.height-25 ));
		GUILayout.BeginHorizontal();
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

    void OnApplicationQuit()
	{
		Screen.sleepTimeout = SleepTimeout.SystemSetting;

		UnityThinkGear.StopStream();
		UnityThinkGear.Close();
	}
}
