using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Earth_light : MonoBehaviour {

	public GameObject light;
	float lockTime = 0f;

	// Use this for initialization
	void Start () {
	
		//light.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > lockTime)
			light.SetActive(false);
	}

	public void lightShow(){

		print ("light");
		lockTime = Time.time + 2;
		light.SetActive(true);
	}

	/*
	void LighProcessing(int i)
	{ 

		if (i == 0 && localLock == 0)
		{
			lockTime = Time.time + 2;
			light.SetActive(false);
			//light60.SetActive(false);
			//light80.SetActive(false);
		}

		if (i == 1)
		{
			light.SetActive(true);
			localLock = 1;
		}
		else if (localLock == 1 && Time.time > lockTime)
		{
			localLock = 0;
		}

		if (i == 2)
		{
			light60.SetActive(true);
			localLock = 2;
		}
		else if (localLock == 2 && Time.time > lockTime)
		{
			localLock = 0;
		}

		if (i == 3)
		{
			light80.SetActive(true);
			localLock = 3;
		}
		else if (localLock == 3 && Time.time > lockTime)
		{
			localLock = 0;
		}
		*/
	//}
}
