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
   
	void Update () {

        if (!GDATA.Instance.isDemo){

             if (!GDATA.Instance.isSignal)
            
            {
				connectMenu.SetActive (true);
				gamesMenus.SetActive (false);
			}
        }
        else
        {
            connectMenu.SetActive(false);
            gamesMenus.SetActive(true);
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
        SceneManager.LoadScene("ColorScene");
        GetComponent<AudioSource>().Play();
    }

    public void LoadDuckGame()
    {
        SceneManager.LoadScene("DuckKill");
        GetComponent<AudioSource>().Play();
    }
}
