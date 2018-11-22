using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectMenu : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;
	public Button connectButton;
	public Text longTimeConnection;
    public Text buttonConnectionText;

    public void Start()
    {
       // CONNECTOR.Instance = GetComponent<CONNECTOR>();
    }

    public void StartBtn()
	{
		CONNECTOR.Instance.OpenConnection();		
	}

	void OnEnable ()
	{
		CONNECTOR.Instance.initConnection ();
	}

	void Update () {

        //if (GDATA.Instance.isSignal)
        if (CONNECTOR.Instance.isSignal)
        {
			connectMenu.SetActive (false);
			gamesMenus.SetActive (true);
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
        //GDATA.Instance.isDemo = true;
        CONNECTOR.Instance.isDemo = true;
        connectMenu.SetActive(false);
        gamesMenus.SetActive(true); 
    }
}
