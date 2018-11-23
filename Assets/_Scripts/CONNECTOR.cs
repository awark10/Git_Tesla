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

            if (GDATA.Instance.isSignal) {
           
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
