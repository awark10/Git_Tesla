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

	int val_1;
	public void play(int val, int[] ladLevel, float[,] soundArray)
	{
		slider.value = val;

		if (val >= ladLevel[0] && val < ladLevel[1] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[0,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[0,1] - soundArray[0,0]));

			val_1 = val;
		}
		if (val >= ladLevel[1] && val < ladLevel[2] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[1,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[1,1] - soundArray[1,0]));

			val_1 = val;
		}
		if (val >= ladLevel[2] && val < ladLevel[3] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[2,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[2,1] - soundArray[2,0]));

			val_1 = val;
		}
		if (val >= ladLevel[3] && val < ladLevel[4] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[3,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[3,1] - soundArray[3,0]));

			val_1 = val;
		}
		if (val >= ladLevel[4] && val < ladLevel[5] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[4,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[4,1] - soundArray[4,0]));

			val_1 = val;
		}
		if (val >= ladLevel[5] && val < ladLevel[6] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[5,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[5,1] - soundArray[5,0]));

			val_1 = val;
		}
		if (val >= ladLevel[6] && val <= ladLevel[7] && val_1 != val) 
		{
			MpPlayer.Stop ();
			MpPlayer.time = soundArray[6,0];
			MpPlayer.Play ();
			MpPlayer.SetScheduledEndTime(AudioSettings.dspTime + (soundArray[6,1] - soundArray[6,0]));

			val_1 = val;
		}
	}
}

