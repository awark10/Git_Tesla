using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Earth_light : MonoBehaviour {

	public GameObject light;
	float lockTime = 0f;
	
	void Update () {

		if (Time.time > lockTime)
		light.SetActive(false);
     
	}

	public void lightShow(){

		
		lockTime = Time.time + 2;
		light.SetActive(true);
	}
}
