using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONNECTOR : MonoBehaviour {

	public static CONNECTOR Instance { get; set;}

	public bool connectionStart = false;
	public int timeConnection = 0;

	public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	private float animationInterval = 0.06f;

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

	public void initConnection()
	{	
		UnityThinkGear.StopStream();
	}

	public void cleanStatIcon(){
		indexSignalIcons = 1;
	}

	public void openConnection(){

		timeConnection = 0;
		connectionStart = true;

		StartCoroutine(ConnectionFunc());
		UnityThinkGear.StartStream();
	}

	IEnumerator ConnectionFunc()
	{

		while (true) 
		{
			timeConnection++;

			if (GDATA.Instance.isSignal) {

				indexSignalIcons = 0;
				connectionStart = false;
				break;

			} else if (timeConnection > 10) 
			{
				connectionStart = false;
				UnityThinkGear.StopStream();
				break;
			}
				
			yield return new WaitForSeconds (1f);
		}
	}


	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(Screen.width - 35);
		GUILayout.Label(signalIcons[(int)indexSignalIcons]);
		GUILayout.EndHorizontal();
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

	}

	void OnApplicationQuit()
	{
		UnityThinkGear.StopStream();
		UnityThinkGear.Close();
	}
}
