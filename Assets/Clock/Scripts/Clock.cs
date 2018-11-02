using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	//-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
	public int seconds = 0;
	public bool realTime=true;
    public AudioClip clip;
	public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;

    //-- time speed factor
    [Range(-1.0f, 1.0f)]
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster
    public float rotateSecondAngle = 0;
    //-- internal vars
   public float msecs=0;
   // public float rotationSpeed = 1.0f;
    void Start() 
{
        //  clockSpeed = 120.0f;
        //-- set real time
      //  GetComponent<AudioSource>().clip = clip;
        if (realTime)
	{
		hour=System.DateTime.Now.Hour;
		minutes=System.DateTime.Now.Minute;
		seconds=System.DateTime.Now.Second;
            rotateSecondAngle = System.DateTime.Now.Second;

        }
}

void Update() 
{
    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;
      /*  rotateSecondAngle += Time.deltaTime * clockSpeed;
        if (rotateSecondAngle >= 60)
            rotateSecondAngle = 0;*/
    if (msecs >= 1.0f)
    {
        msecs -= 1.0f;
            seconds++;
           // GetComponent<AudioSource>().Play();
            // AudioSource
            //clip.// = seconds+ Time.deltaTime;
            if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }
        if (msecs <= -1.0f)
        {
            msecs += 1.0f;
            seconds--;
            GetComponent<AudioSource>().Play();
            // AudioSource
            //clip.// = seconds+ Time.deltaTime;
            if (seconds <= 0)
            {
                seconds = 60;
                minutes--;
                if (minutes < 1)
                {
                    minutes = 60;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }
        }
        // tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}
}
