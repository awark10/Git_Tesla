using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacController : MonoBehaviour {

	public AudioSource MpPlayer;
	public AudioClip MpClip;
	public Slider slider;
	// Use this for initialization
	void Start () 
	{
		MpPlayer = GetComponent<AudioSource> ();
		MpPlayer.clip = MpClip;
	}

	// Update is called once per frame
	void Update () {

	}

	public void play(int val, int[] ladLevel, float[,] soundArray)
	{
		MpPlayer.Stop ();
		slider.value = val;

		if (val >= ladLevel[0] && val < ladLevel[1]) 
		{
			MpPlayer.time = soundArray[0,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[0,1] - soundArray[0,0]));
		}
		if (val >= ladLevel[1] && val < ladLevel[2]) 
		{
			MpPlayer.time = soundArray[1,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[1,1] - soundArray[1,0]));
		}
		if (val >= ladLevel[2] && val < ladLevel[3]) 
		{
			MpPlayer.time = soundArray[2,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[2,1] - soundArray[2,0]));
		}
		if (val >= ladLevel[3] && val < ladLevel[4]) 
		{
			MpPlayer.time = soundArray[3,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[3,1] - soundArray[3,0]));
		}
		if (val >= ladLevel[4] && val < ladLevel[5]) 
		{
			MpPlayer.time = soundArray[4,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[4,1] - soundArray[4,0]));
		}
		if (val >= ladLevel[5] && val < ladLevel[6]) 
		{
			MpPlayer.time = soundArray[5,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[5,1] - soundArray[5,0]));
		}
		if (val >= ladLevel[6] && val < ladLevel[7]) 
		{
			MpPlayer.time = soundArray[6,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[6,1] - soundArray[6,0]));
		}
	}
}

