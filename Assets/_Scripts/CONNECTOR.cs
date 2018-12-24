using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONNECTOR : MonoBehaviour {

	public static CONNECTOR Instance { get; set;}
	ThinkGearController controller;

	public bool connectionStart = false;
	public bool isSignal = false;
	private float poorSignal=0;
	private int timeConnection = 0;

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
		controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;

		// Never Turn OFF Screen
		Screen.sleepTimeout = SleepTimeout.NeverSleep;  
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

    void OnApplicationQuit()
	{
		Screen.sleepTimeout = SleepTimeout.SystemSetting;

		UnityThinkGear.StopStream();
		UnityThinkGear.Close();
	}
}
