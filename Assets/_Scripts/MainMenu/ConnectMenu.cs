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
    //public GameObject profileHeaderMenu;



    public void StartBtn()
	{
		CONNECTOR.Instance.OpenConnection();
       // profileHeaderMenu.SetActive(true);

    }

	void OnEnable ()
	{
		//CONNECTOR.Instance.initConnection ();
	}

	void Update () {

       
        if (GDATA.Instance.isSignal)
        {
			connectMenu.SetActive (false);
			gamesMenus.SetActive (true);
		}

		else if (CONNECTOR.Instance.connectionStart) 
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
       GDATA.Instance.isDemo = true;
        connectMenu.SetActive(false);
        gamesMenus.SetActive(true); 
    }
}
