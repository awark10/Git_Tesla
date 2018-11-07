using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectMenu : MonoBehaviour {

	ThinkGearController controller;

	public GameObject connectMenu;
	public GameObject gamesMenus;
	//public GameObject connectLoader;
	//public GameObject statusConnectionImage;
	public Button connectButton;
	public Text longTimeConnection;
    public Text buttonConnectionText;

	public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	private float animationInterval = 0.06f;

	public bool connectionStart = false;
	public int timeConnection = 0;

	void OnEnable ()
	{
		connectionStart = false;
		timeConnection = 0;
		indexSignalIcons = 1;

		//connectLoader.SetActive(false);
		connectButton.interactable = true;
		//statusConnectionImage.SetActive(true);
	}

	public void StartBtn()
	{
		connectionStart = true;
		//connectLoader.SetActive(true);
		connectButton.interactable = false;
        buttonConnectionText.text = "ПОДКЛЮЧЕНИЕ";

        longTimeConnection.text = "";
		//statusConnectionImage.SetActive(false);
		timeConnection = 0;
        StartCoroutine(ConnectionFunc());
        UnityThinkGear.StartStream();
		
	}

	IEnumerator ConnectionFunc()
	{

		while (true) 
		{

			if (ThinkGearController.Instance.poorSignalStatus == 1 || ThinkGearController.Instance.poorSignalStatus == 2) {

				connectMenu.SetActive (false);
				gamesMenus.SetActive (true);

                Debug.Log("ok");
				break;

				} else if (timeConnection > 10) 
			{
                Debug.Log("not ok");
                longTimeConnection.text = "";// "No connection" + "\r\n" + "Try reconnect";
				connectButton.interactable = true;
                //statusConnectionImage.SetActive (true);
                //connectLoader.SetActive (false);
                buttonConnectionText.text = "ПОДКЛЮЧИТЬ";
                connectionStart = false;
				indexSignalIcons = 1;

				UnityThinkGear.StopStream();
				break;

			}

			timeConnection++;
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

    public void Demo()
    {
        GamesMenu.demo = true;
        connectMenu.SetActive(false);
        gamesMenus.SetActive(true);
        
    }
}
