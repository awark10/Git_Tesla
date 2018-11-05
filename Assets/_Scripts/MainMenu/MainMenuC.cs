using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class MainMenuC : MonoBehaviour {
    public GameObject modeMenu;
   // public GameObject mainMenu;

    public GameObject connectMenu;
    public GameObject connectLoader;
    public GameObject statusConnectionImage;
    public Button connectButton;
    public float timeConnection;
    public Text longTimeConnection;
    ThinkGearController controller;
    public int PoorSignal;
    public bool connecting;
    public bool challenge=false;
    public bool connected;
    public static bool connectionDone= false;
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
       controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        longTimeConnection.text = "Мотивационный текст для старта взаимодействия с приложением";
    }
	
	// Update is called once per frame
	void Update () {
       if (connecting) Connection();
       if (connectionDone)
            ConnectionStatus(PoorSignal);
       }

    public void StartConnection()
    {
        connectLoader.SetActive(true);
        connectButton.interactable = false;
        connecting = true;
         longTimeConnection.text = "";
        statusConnectionImage.SetActive(false);
          UnityThinkGear.StartStream();            ////  ЗАЧЕМ?
    }

    public void ConnectionStatus(int startwork )
    { 
            if (startwork ==0)   //PoorSignal == 0 Debug
        {
            connected = true;
                connectLoader.SetActive(false);
                connectMenu.SetActive(false);
                statusConnectionImage.SetActive(false);
            modeMenu.SetActive(true);
        }
            else 
            {
                longTimeConnection.text = "No connection" + "\r\n" + "Try reconnect";
                connectMenu.SetActive(true);
                connectButton.interactable = true;
                statusConnectionImage.SetActive(true);
                connecting = false;
              //  mainMenu.SetActive(false);
                modeMenu.SetActive(false);
            connectionDone = false;
            }
    }
    
    public void Demo()
    {
        connectMenu.SetActive(false);
        modeMenu.SetActive(true);
    }

    public void Connection()
    {
       // mainMenu.SetActive(false);
        timeConnection += Time.deltaTime;
       
        if (PoorSignal == 0)
            {
                connectLoader.SetActive(false);
                modeMenu.SetActive(true);
                connectMenu.SetActive(false);
                statusConnectionImage.SetActive(false);
                timeConnection = 0;
                connecting = false;
            connected = true;
            connectionDone = true;
           
        }
            else if (timeConnection > 20.0f && PoorSignal != 0)
            {
                longTimeConnection.text = "No connection" + "\r\n" + "Try reconnect";
                timeConnection = 0;
                connectButton.interactable = true;
                statusConnectionImage.SetActive(true);
                connecting = false;
                connectLoader.SetActive(false);
                timeConnection = 0;
            }
    }

    void OnUpdatePoorSignal(int value)
    {
        PoorSignal = value;
     // if (PoorSignal == 0) 

    }

    public void Challenge()
    {
            challenge = true;
            modeMenu.SetActive(false);
        //    mainMenu.SetActive(true);
    }
    public void TrainingGames()
    {
            modeMenu.SetActive(false);
         //   mainMenu.SetActive(true);
    }

    public void LoadTimeGame()
    {
        SceneManager.LoadScene("ClockScene");
    }
    public void LoadEarthGame()
    {
        SceneManager.LoadScene("EarthScene");
        _StatScript.PoorSignal = PoorSignal;
    }


}
