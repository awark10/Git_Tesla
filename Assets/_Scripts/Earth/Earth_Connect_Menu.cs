using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Earth_Connect_Menu : MonoBehaviour {

	public GameObject gameUI;
	public GameObject connectMenu;

	public Button connectButton;
	public Text buttonConnectionText;
	public Text longTimeConnection;

	void OnEnable ()
	{
		CONNECTOR.Instance.initConnection ();
	}

	public void StartBtn()
	{
		CONNECTOR.Instance.openConnection();		
	}

	void Update () {

		if (GDATA.Instance.isSignal)
		{
			connectMenu.SetActive (false);
			gameUI.SetActive (true);
		}

		if (CONNECTOR.Instance.connectionStart) 
		{
			connectButton.interactable = false;
			buttonConnectionText.text = "ПОДКЛЮЧЕНИЕ";
		} 
		else 
		{
			buttonConnectionText.text = "ПОДКЛЮЧИТЬ";
			connectButton.interactable = true;
			CONNECTOR.Instance.cleanStatIcon ();
		}
	}

	public void Demo()
	{
		GDATA.Instance.Attention = 34;
		GDATA.Instance.Meditation = 58;
		GDATA.Instance.isDemo = true;
		connectMenu.SetActive(false);
		gameUI.SetActive(true);
	}
}
