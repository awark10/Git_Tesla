using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour {
    GDATA data;

    public Text avgMedText, deepMedText, avgAttText, deepAttText;
    // Use this for initialization
    void Start()
    {
        data = GDATA.Instance.GetComponent<GDATA>();
        avgMedText.text = "" + (int)data.avgMeditation;
        avgAttText.text = "" + (int)data.avgAttention;
        deepMedText.text = "" + data.deepMeditationTime+"s";
        deepAttText.text = "" + data.deepAttentionTime+"s";
    }

    public void ResetUserStat()
    {
        data.ResetEEG();
        avgMedText.text = "0";
        avgAttText.text = "0";
        deepMedText.text = "0s" ;
        deepAttText.text = "0s" ;
    }

}
