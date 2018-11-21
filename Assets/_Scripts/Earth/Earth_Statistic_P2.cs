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

	public Text ballsTextVal;

	// Use this for initialization
	void Start () {

		
	}
    private void OnEnable()
    {
        ballsTextVal.text = statistic.ballsVal.ToString();

        medQualText.text = "Meditation quality";
        medQualTextVal.text = (int)statistic.medQual + " %";

        attQualText.text = "Attention quality";
        attQualTextVal.text = (int)statistic.attQual + " %";

        medAvgText.text = "Avg. meditation time";
        medAvgTextVal.text = statistic.medMinutes + ":" + statistic.medSeconds + " min";

        attAvgText.text = "Avg. attention time";
        attAvgTextVal.text = statistic.attMinutes + ":" + statistic.attSeconds + " min";
    }
}


