using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;
    public AudioClip clickSound;

    public void Start()
    {
        GetComponent<AudioSource>().clip = clickSound;
    }
    void OnEnable () {

		gamesMenus.SetActive (true);
	}

	void Update () {

        if (!GDATA.Instance.isDemo){
       

             if (!GDATA.Instance.isSignal)
            
            {
				connectMenu.SetActive (true);
				gamesMenus.SetActive (false);
			}
        }
    }

	public void LoadTimeGame()
	{
		SceneManager.LoadScene("ClockScene");
        GetComponent<AudioSource>().Play();
    }

	public void LoadEarthGame()
	{
		SceneManager.LoadScene("EarthScene");
        GetComponent<AudioSource>().Play();
    }

    public void LoadColorsGame()
    {
        SceneManager.LoadScene("ColorsScene");
        GetComponent<AudioSource>().Play();
    }
}
