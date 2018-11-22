using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONNECTOR : MonoBehaviour {

	public static CONNECTOR Instance { get; set;}

	public bool connectionStart = false;
	public int timeConnection = 0;
    
    public Texture2D[] signalIcons;
	public static float indexSignalIcons = 1;
	private float animationInterval = 0.06f;
    public Text debugTextField;

    
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

    //---------------------------------------
    //---------------------------------------------
    public bool isDemo = false;
    public bool isSignal = false;
    private int Raw = 0;
    ThinkGearController gearController;
    public float poorSignal = 0;
    [Range(0, 100)]
    public int Attention = 0;
    [Range(0, 100)]
    public int Meditation = 0;

    public void Start()
    {
        UnityThinkGear.Init(true);
        gearController = GameObject.Find("GDATA").GetComponent<ThinkGearController>();
        gearController.UpdateRawdataEvent += OnUpdateRaw;
        gearController.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        gearController.UpdateAttentionEvent += OnUpdateAttention;
        gearController.UpdateMeditationEvent += OnUpdateMeditation;
        debugTextField.text += " UnityThinkGear.Init ";

    }

    public void Update()
    {
        if (poorSignal > 0)
            debugTextField.text += " VaLUE =" + poorSignal;
    }

    void OnUpdateRaw(int value)
    {
        Raw = value;
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
            connectionStart = false;
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
    //--------------------------------
    //------------------------------------

    public void initConnection()
	{	
		//UnityThinkGear.StopStream();
	}

	public void cleanStatIcon(){
		indexSignalIcons = 1;
	}

	public void OpenConnection(){

		timeConnection = 0;
		connectionStart = true;
        UnityThinkGear.StartStream();
        StartCoroutine(ConnectionFunc());
		
        debugTextField.text += "UnityThinkGear.StartStream";
        

    }

	IEnumerator ConnectionFunc()
	{

		while (true) 
		{
			timeConnection++;

            //if (GDATA.Instance.isSignal) {
            if (isSignal)
            {
                indexSignalIcons = 0;
				connectionStart = false;
				break;

			} else if (timeConnection > 15) 
			{
				connectionStart = false;
				//UnityThinkGear.StopStream();
				break;
			}
				
			yield return new WaitForSeconds (1f);
		}
	}


	void OnGUI()
	{
        GUILayout.BeginArea(new Rect(Screen.width - 50, 10, Screen.width-15 , Screen.height-10 ));
		GUILayout.BeginHorizontal();
        //GUILayout.Label("Demo");
      //  GUILayout.Height(Screen.height - 255);
        //GUILayout.Space(Screen.width - 55);
        
        GUILayout.Label(signalIcons[(int)indexSignalIcons]);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
	}
/*
    rectX = Screen.width / 10;
		rectY = Screen.height / 3;
		rectWidth = Screen.width* 8 / 10;
		rectHeight = Screen.height / 4;
        */
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
