using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDATA : MonoBehaviour {

	public static GDATA Instance { get; set;}
	public ThinkGearController controller;

	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	public string userName = "Petro";
	public int userAge = 29;

	public bool isDemo = false;
	public bool isSignal = false;

	void Awake (){

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
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update (){
	}

	void OnUpdatePoorSignal(int value)
	{

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

	void OnUpdateAttention(int value)
	{ 
		Attention = value;
	}

	void OnUpdateMeditation(int value)
	{
		Meditation = value;
	}

	void OnApplicationQuit()
	{

		Screen.sleepTimeout = SleepTimeout.SystemSetting;
	}
}
