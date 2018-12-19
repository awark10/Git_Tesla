using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDATA : MonoBehaviour {

	public static GDATA Instance { get; set;}
    public Text debugText;
    public string userName = "Petro";
	public int userAge = 29;

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

		print ("GDATA - Awake");
    }


    void Start () 
	{  
    }
		
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(35, 125, Screen.width - 25, Screen.height - 25));
		GUILayout.BeginVertical();
		// GUILayout.Label("Raw:" + Raw);
		// GUILayout.Label("Signal:" + poorSignal);
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
