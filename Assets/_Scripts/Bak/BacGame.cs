using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacGame : MonoBehaviour {

	GDATA data;

	public BacController bacDelta, bacTheta, bacAlphaH, bacAplhaL, bacBetaH, bacBetaL, bacGammaH, bacGammaL;

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
            SceneManager.LoadScene("MenuScene");
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
			bacDelta.play (data.Delta, data.avgDelta, ladLevel, DeltaSoundArray);

		if (data.getIsNewTheta()) 
			bacTheta.play (data.Theta, data.avgTheta, ladLevel, DeltaSoundArray);

		if (data.getIsNewHighAlpha()) 
			bacAlphaH.play (data.HighAlpha, data.HighAlpha, ladLevel, DeltaSoundArray);
	}

	void UIupdate()
	{
		
	}
}
