using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Earth_Statistic_P2 : MonoBehaviour {

	public Earth_Statistic_P1 statistic;

	public Text medQualTextVal;
	public Text medQualText;

	// Use this for initialization
	void Start () {

		medQualText.text = "Meditation quality";	
		medQualTextVal.text = "67%";
	}
}
