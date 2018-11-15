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
		medQualTextVal.text = "10%";

		attQualText.text = "Attention quality";	
		attQualTextVal.text = "20%";

		medAvgText.text = "Avg. meditation time";	
		medAvgTextVal.text = "30 min";

		attAvgText.text = "Avg. attention time";	
		attAvgTextVal.text = "40 min";
	}
}


