using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacGame : MonoBehaviour {

	GDATA data;

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
		
	}

	void UIupdate()
	{
		
	}
}
