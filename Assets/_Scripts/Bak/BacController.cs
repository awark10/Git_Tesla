using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacController : MonoBehaviour {

	AudioSource MpPlayer;
	public AudioClip MpClip;
	public Slider slider;
    public GameObject mask;
    public Text currentValText, avgValText;
    int sliderNewVal;
	int lad_1;
	public bool controllerState;

	// Use this for initialization
	void Start () 
	{
		MpPlayer = GetComponent<AudioSource> ();
		MpPlayer.clip = MpClip;
        slider.value = 0;
        currentValText.text = "0";
        avgValText.text = "0";
		lad_1 = -1;
        controllerState = true;
    }

	public void ChangeState()
	{
		controllerState = !controllerState;
	}

	// Update is called once per frame
	void Update ()
    {
		if (controllerState)
		{
			mask.SetActive(false);
			slider.value = Mathf.Lerp(slider.value, sliderNewVal, Time.deltaTime * 5);
		} 
		else 
		{
			mask.SetActive(true);
			slider.value = 0;
			currentValText.text = "0";
			avgValText.text = "0";
			lad_1 = -1;
			MpPlayer.Stop();
		}
    }

   	public void play(int val, float avg, int[] ladLevel, float[,] soundArray)
	{
		if (controllerState)
        {
            sliderNewVal = val;
            currentValText.text = ""+val;
            avgValText.text = ""+ (int)avg;

            if (val >= ladLevel[0] && val < ladLevel[1] && lad_1 != 0)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[0, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[0, 1] - soundArray[0, 0]));

                lad_1 = 0;
            }
            if (val >= ladLevel[1] && val < ladLevel[2] && lad_1 != 1)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[1, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[1, 1] - soundArray[1, 0]));

                lad_1 = 1;
            }
            if (val >= ladLevel[2] && val < ladLevel[3] && lad_1 != 2)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[2, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[2, 1] - soundArray[2, 0]));

                lad_1 = 2;
            }
            if (val >= ladLevel[3] && val < ladLevel[4] && lad_1 != 3)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[3, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[3, 1] - soundArray[3, 0]));

                lad_1 = 3;
            }
            if (val >= ladLevel[4] && val < ladLevel[5] && lad_1 != 4)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[4, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[4, 1] - soundArray[4, 0]));

                lad_1 = 4;
            }
            if (val >= ladLevel[5] && val < ladLevel[6] && lad_1 != 5)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[5, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[5, 1] - soundArray[5, 0]));

                lad_1 = 5;
            }
            if (val >= ladLevel[6] && val <= ladLevel[7] && lad_1 != 6)
            {
                MpPlayer.Stop();
                MpPlayer.time = soundArray[6, 0];
                MpPlayer.Play();
                MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[6, 1] - soundArray[6, 0]));

                lad_1 = 6;
            }
        } 
	}
}

