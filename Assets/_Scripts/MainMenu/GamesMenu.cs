using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamesMenu : MonoBehaviour {

	private CONNECTOR connector;
	public GameObject gamesMenus;
    public AudioClip clickSound;
    public UserMenu userMenu;
	public Image stateImg;

    public void Start()
    {
        GetComponent<AudioSource>().clip = clickSound;
		connector = CONNECTOR.Instance.GetComponent<CONNECTOR>();
    }

	private float animationInterval = 0.015f;
	private float time;

	void Update ()
	{
		if (connector.connectionStart)
		{

			if (time < 1) 
			{
				stateImg.color = Color.blue;
				time += animationInterval;
			}
			else if (time >= 1 && time <2)
			{
				stateImg.color = Color.white;
			}
			else if(time >= 2)
				time = 0;

			time += animationInterval;

		} else if (connector.isSignal == true)
			stateImg.color = Color.green;
		else if (connector.isSignal == false)
			stateImg.color = Color.black;
	}

    public void ShowGameMenu()
    { if(userMenu.opened ==true)
        userMenu.ChangeState();
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
        SceneManager.LoadScene("ColorScene");
        GetComponent<AudioSource>().Play();
    }

    public void LoadDuckGame()
    {
        SceneManager.LoadScene("DuckKill");
        GetComponent<AudioSource>().Play();
    }
    public void LoadNATGame()
    {
        SceneManager.LoadScene("BAK");
        GetComponent<AudioSource>().Play();
    }
}
