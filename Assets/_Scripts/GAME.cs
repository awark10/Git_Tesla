using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour {

	public static GAME Instance { get; set;}
	public ThinkGearController controller;

	public int poorSignalStatus = 0;
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
			poorSignalStatus = 0;
		} 
		else if (value == 0)  // Stable connection
		{
			poorSignalStatus = 2;
		} 
		else // Weak connection
		{
			poorSignalStatus = 1;
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
