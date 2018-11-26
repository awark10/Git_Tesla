﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDATA : MonoBehaviour {

	public static GDATA Instance { get; set;}

	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	public string userName = "Petro";
	public int userAge = 29;

	public bool isDemo = false;
	public bool isSignal = false;
    public Text debugTextField;
    public float poorSignal=0;
   // ThinkGearController gearController;
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
      //  gearController = GetComponent<ThinkGearController>();

    }

    ThinkGearController controller;

    void Start () 
	{
        // ThinkGearController.Instance = GetComponent<ThinkGearController>();

        //controller = ThinkGearController.Instance.GetComponent<ThinkGearController>();

        ThinkGearController.Instance.GetComponent<ThinkGearController>().UpdateAttentionEvent += OnUpdateAttention;
        ThinkGearController.Instance.GetComponent<ThinkGearController>().UpdateMeditationEvent += OnUpdateMeditation;
        ThinkGearController.Instance.GetComponent<ThinkGearController>().UpdatePoorSignalEvent += OnUpdatePoorSignal;
        /*
        gearController.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        gearController.UpdateAttentionEvent += OnUpdateAttention;
        gearController.UpdateMeditationEvent += OnUpdateMeditation;
       */

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (ThinkGearController.Instance == null)
            debugTextField.text += "\r\n" + " ThinkGearController.Instance = null ";
        else
        debugTextField.text += "\r\n" + " ThinkGearController.Instance OK ";

    }

	void Update (){
        if (poorSignal >0 )
        debugTextField.text += " VaLUE =" + poorSignal;
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
