using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_connection_monitor : MonoBehaviour {

	public GameObject gameUI;
	public GameObject connectMenu;
	
	// Update is called once per frame
	void Update () {


	}

	/*
	public float ConnectionMinitorVal = 0;
    public float ConnectionMinitorTime = 0;

	void ConnectionMinitor()
	{

		if (gameUI.activeSelf == true)
		{

			ConnectionMinitorTime += Time.deltaTime;

			if (ConnectionMinitorVal != Attention)
			{
				ConnectionMinitorVal = Attention;
				ConnectionMinitorTime = 0;
			}

			if (ConnectionMinitorTime > 15)
			{
				//  startMenu.SetActive(true);
				//   backGr.SetActive(true);
				gameUI.SetActive(false);
				ConnectionMinitorTime = 0;

				// connect.interactable = true;
				UnityThinkGear.Close();
			}
		}
	}
	*/
}
