using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamesMenu : MonoBehaviour {

	private CONNECTOR connector;
	public GameObject gamesMenus;
    public AudioClip clickSound;
    public UserMenu userMenu;
	public Image stateImg;
    public Text stateText;

    public void Start()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().clip = clickSound;
		connector = CONNECTOR.Instance.GetComponent<CONNECTOR>();
    }

	private float animationInterval = 0.015f;
	private float time;

	void Update ()
	{
        if (connector.connectionStart)
        {
            stateText.text = "подключение";
            if (time < 0.25f)
            {
                stateImg.color = Color.blue;
               // stateImg.fillAmount = Mathf.Lerp(0, 1, time);
                time += Time.deltaTime;
            }
            else if (time >= 0.25f && time < 0.5f)
            {
                stateImg.color = Color.white;
            }
            else if (time >= 0.5f)
                time = 0;

            time += Time.deltaTime;

        }
        else if (connector.isSignal == true)
        {
            stateImg.color = Color.green;
            stateImg.fillAmount = 1;
            stateText.text = "подключено";
        }
        else if (connector.isSignal == false)
            stateImg.color = Color.black;
        stateText.text = "подключить";
    }

    public void ShowGameMenu()
    { if(userMenu.opened ==true)
        userMenu.ChangeState();
    }
    public void LoadEarthGame()
    {
        SceneManager.LoadScene("LoadingScene");
        SceneLoader.sceneId = 2;
        GetComponent<AudioSource>().Play();
    }

    public void LoadTimeGame()
	{
		SceneManager.LoadScene("LoadingScene");
        SceneLoader.sceneId = 3;
        GetComponent<AudioSource>().Play();
    }
    public void LoadDuckGame()
    {
        SceneManager.LoadScene("LoadingScene");
        SceneLoader.sceneId = 4;
        GetComponent<AudioSource>().Play();
    }
    public void LoadNATGame()
    {
        SceneManager.LoadScene("LoadingScene");
        SceneLoader.sceneId = 5;
        GetComponent<AudioSource>().Play();
    }
}
