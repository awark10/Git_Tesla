using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockGame : MonoBehaviour {

	GDATA data;

    public Clock clock;
    public GameObject fog;
    public GameObject gameUI;
   // public GameObject connectMenu;
   // public GameObject pauseMenu;

    public Text attText;
    public Text medText;
    public Image attSlImage;
    public Image medSlImage;

    [Header("Received Values")]
    [Range(0, 100)]
    public int Attention = 0;
    [Range(0, 100)]
    public int Meditation = 0;

    private float tmpMedSliderVal = 0;
    private float tmpAtSliderVal = 0;

	public float saveTime; 

    public bool gameAtt = true;
    
	// Use this for initialization
    void Start () 
	{
		data = GDATA.Instance.GetComponent<GDATA>();

		clock.hour = System.DateTime.Now.Hour;
		clock.minutes = System.DateTime.Now.Minute;
		clock.seconds = System.DateTime.Now.Second;
		clock.rotateSecondAngle = System.DateTime.Now.Second;

        GameAtt();
    }

    void Update()
    {
		data.normalize ();

		Attention = data.Attention;
		Meditation = data.Meditation;

        if (gameAtt == true)
            GameLogic(Attention);
        else 
			GameLogic(Meditation);

        UIupdate();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ShowPauseMenu();
        }
    }

    public void GameAtt()
    {
        gameAtt = true;
        fog.GetComponent<ParticleSystem>().startColor = Color.red;
        attText.color = Color.black;
        attSlImage.color = Color.red;
        medText.color = Color.gray;
        medSlImage.color = Color.gray;
    }

    public void GameMed()
    {
        gameAtt = false;
        fog.GetComponent<ParticleSystem>().startColor = Color.green;
        attText.color = Color.gray;
        attSlImage.color = Color.gray;
        medText.color = Color.black;
        medSlImage.color = Color.green;
    }

    public float lock90;
    public void GameLogic(int value)
	{
		if (value > 90)
		{
			lock90 += Time.deltaTime;
			if (lock90 > 7)
				clock.clockSpeed = -1f;
			else
				clock.clockSpeed = 0.2f;
		}
		else if (value > 80)
			clock.clockSpeed = 0.4f;
		else if (value > 70)
			clock.clockSpeed = 0.6f;
		else if (value > 50)
			clock.clockSpeed = 0.8f;
		else
			clock.clockSpeed = 1f;

		if (value < 90)
			lock90 = 0;     

		if (value > 65)
			saveTime += Time.deltaTime;
    }

   
	void UIupdate() 
	{
		attText.text = "" + Attention+"%";
		medText.text = "" + Meditation+"%";

		tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
		tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
		attSlImage.fillAmount = tmpAtSliderVal / 100;
		medSlImage.fillAmount = tmpMedSliderVal / 100;

		clock.UpdateLogic ();
	}
}
