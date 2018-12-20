using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONNECTOR : MonoBehaviour {

	public static CONNECTOR Instance { get; set;}
	ThinkGearController controller;

	public bool connectionStart = false;
	public int timeConnection = 0;
    
    public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	private float animationInterval = 0.06f;

	public bool isSignal = false;
	public float poorSignal=0;

	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

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

				Attention = 49;
				Meditation = 51;
				break;
			}
				
			yield return new WaitForSeconds (1f);
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
