using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Init : MonoBehaviour {

	public GameObject gameUI;
	public Texture2D[] signalIcons;

	// Use this for initialization
	void Start () {

		gameUI.SetActive (true);

	}

	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Space(Screen.width - 35);
		GUILayout.Label(signalIcons[0]);
		GUILayout.EndHorizontal();
	}
}
