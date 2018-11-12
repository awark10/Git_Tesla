using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour {

	public static GAME Instance { get; set;}
	public ThinkGearController controller;

	public bool isConnected = false;
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	public string userName = "Petro";
	public int userAge = 29;

	public bool isDemo = false;

	void Awake (){

		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

	}

	void Start () 
	{

		//controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
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
			isConnected = false;
		} 
		else if (value == 0)  // Stable connection
		{
			isConnected = true;
		} 
		else // Weak connection
		{
			isConnected = true;
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
}
