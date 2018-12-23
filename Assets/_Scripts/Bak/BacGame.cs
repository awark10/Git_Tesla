using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacGame : MonoBehaviour {

	GDATA data;

	public BacController bacDelta;

	int [] ladLevel = {0,15,30,45,60,75,90,100};
	float [,] DeltaSoundArray = { {0f,10f}, {11.2f,20f}, {21.4f,31f}, {33.6f,45f}, {47.3f,59f}, {60.8f,73f}, {74.8f,84f} };

	void Start () {

		data = GDATA.Instance.GetComponent<GDATA>();
	}
	
	void Update () 
	{

		gameLogic ();
		UIupdate ();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//ShowPauseMenu();
		}
	}

	void gameLogic ()
	{
		if (data.isNewAttention) 
		{


			data.isNewAttention = false;
		}

		if (data.isNewMeditation) 
		{

			data.isNewMeditation = false;
		}

		if (data.getIsNewDelta()) 
			bacDelta.play (data.Delta, ladLevel, DeltaSoundArray);

		if (data.isNewTheta) 
		{


			data.isNewTheta = false;
		}
	}

	void UIupdate()
	{
		
	}
}
