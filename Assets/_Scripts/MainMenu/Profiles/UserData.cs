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
        deepMedText.text = "" + data.deepMeditationTime;
        deepAttText.text = "" + data.deepAttentionTime;
    }
}
