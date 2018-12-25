using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotator : MonoBehaviour {

    public Image image;
    public float step;
    	
	void Update () {
        step += Time.deltaTime;
        image.fillAmount = Mathf.Lerp(0, 1, step);
        if (step >= 2f) step = 0;
	}
}
