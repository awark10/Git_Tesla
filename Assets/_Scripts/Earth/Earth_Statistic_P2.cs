using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Earth_Statistic_P2 : MonoBehaviour {

	public Earth_Statistic_P1 statistic;

	public Text medQualTextVal;
	public Text medQualText;
	public Text attQualTextVal;
	public Text attQualText;
	public Text medAvgTextVal;
	public Text medAvgText;
	public Text attAvgTextVal;
	public Text attAvgText;

	// Use this for initialization
	void Start () {

		medQualText.text = "Meditation quality";	
		medQualTextVal.text = "67%";
	}
}


