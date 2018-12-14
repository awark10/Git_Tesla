using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck_game : MonoBehaviour {

    #region
    [Header("UI elements")]
    
    public GameObject gameUI;
    public GameObject connectMenu;
    public GameObject pauseMenu;
    public Scope_controller scope;

    public Text scoreText;
    public Text countDuckText;
    public int scoreCount;
    public int duckCount;

   // public int tmpDuckLilled;


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

    

    // Initialization
    void Start()
    {
        scoreText.text = "";
       
    }

    void Update()
    {

        if (!GDATA.Instance.isDemo)
        {
            if (GDATA.Instance.isSignal)
            {
                Attention = GDATA.Instance.Attention;
                Meditation = GDATA.Instance.Meditation;

                GameLogic();
                UIupdate();
            }
            else
            {
                StopGame();
               // gameUI.SetActive(false);
                connectMenu.SetActive(true);
            }

            /*if (Input.GetKeyDown (KeyCode.Escape)) {
				pauseMenu.SetActive (true);
				//Time.timeScale = 0;
			}*/
        }
        else
        {
            Attention = GDATA.Instance.Attention;
            Meditation = GDATA.Instance.Meditation;
            UIupdate();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
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
        scoreText.text = "Score: "+scoreCount; 
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
