using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesMenu : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;
    public AudioClip clickSound;

    public void Start()
    {
        GetComponent<AudioSource>().clip = clickSound;
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
}
