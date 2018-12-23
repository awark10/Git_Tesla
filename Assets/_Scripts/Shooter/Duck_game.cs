using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck_game : MonoBehaviour {

	GDATA data;

    #region
    [Header("UI elements")]
    
    public GameObject gameUI;
    public Scope_controller scope;

    public Text scoreText;
    public Text countDuckText;
    public int scoreCount;
    public int duckCount;

    public Text attText;
    public Text medText;
    public Image attSlImage;
    public Image medSlImage;
    #endregion
    [Header("Received Values")]
    [Range(0, 100)]
    public int Attention = 0;
    [Range(0, 100)]
    public int Meditation = 0;

    private float tmpMedSliderVal = 0;
    private float tmpAtSliderVal = 0;

    void Start()
    {
		data = GDATA.Instance.GetComponent<GDATA>();
        scoreText.text = "";
    }

	void Update()
	{
		Attention = data.Attention;
		Meditation = data.Meditation;

		UIupdate ();
		GameLogic ();
	}

    void GameLogic()
    {
        scope.MovingScope(Meditation, Attention);
    }

    public void AddScore(int newscore)
    {
        scoreCount += newscore;
    }

    void UIupdate()
    {

        attText.text = "" + Attention + "%";
        medText.text = "" + Meditation + "%";
        scoreText.text = ""+scoreCount; 
        tmpAtSliderVal = Mathf.Lerp(tmpAtSliderVal, Attention, Time.deltaTime * 5);
        tmpMedSliderVal = Mathf.Lerp(tmpMedSliderVal, Meditation, Time.deltaTime * 5);
        attSlImage.fillAmount = tmpAtSliderVal / 100;
        medSlImage.fillAmount = tmpMedSliderVal / 100;
    }

    void StopGame()
    {
      //  scoreText.text = "";
    }
}
