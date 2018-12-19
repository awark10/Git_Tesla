using UnityEngine;

public class Settings_MM_Controller : MonoBehaviour {
    public Animator animator;
    public GameObject settingsMenu;
    public GameObject gamesMenu;
   // public GameObject connectMenu;
    public GameObject aboutMenu;
    public GameObject closeSettingsBTN;
   // public GameObject profileUpButton;
    public AudioClip clickSound;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("setState", 0);
        aboutMenu.SetActive(false);
        GetComponent<AudioSource>().clip = clickSound;
    }

    public void IdleStay()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
       
        //aboutMenu.SetActive(false);
    }
    public void ShowStatStay()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
    }


    public void OpenedStay()
    {
        animator.SetInteger("setState", 2);
        closeSettingsBTN.SetActive(true);
        
    }
    public void MovingOpen()
    {
        animator.SetInteger("setState", 2);
        closeSettingsBTN.SetActive(true);
       
        GetComponent<AudioSource>().Play();
    }
    public void MovingClose()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
       
        GetComponent<AudioSource>().Play();
    }

    public void Connection()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
        GetComponent<AudioSource>().Play();
        
    }
    
    public void ShowAbout()
    {
        animator.SetInteger("setState", 0);
        aboutMenu.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    public void HideAbout()
    {
        aboutMenu.SetActive(false);
        animator.SetInteger("setState", 2);
        GetComponent<AudioSource>().Play();
    }

    public void AppQuit()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
        Debug.Log("Quit");
    }
	
}
