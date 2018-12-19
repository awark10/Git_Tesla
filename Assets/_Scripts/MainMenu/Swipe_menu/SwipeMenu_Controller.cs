using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeMenu_Controller : MonoBehaviour {
    public Animator animator;
    public GameObject swipeMenu;
    public GameObject aboutMenu;
    public GameObject statMenu;
    public GameObject closeSettingsBTN;
    public AudioClip clickSound;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = clickSound;
        animator = GetComponent<Animator>();
        animator.SetInteger("setState", 0);
    }

    public void IdleStay()
    {
        animator.SetInteger("setState", 0);

    }
    public void OpenedState()
    {
        animator.SetInteger("setState", 1);
    }

    public void ShowAbout()
    {
        
        aboutMenu.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    public void HideAbout()
    {
        aboutMenu.SetActive(false);
        animator.SetInteger("setState", 0);
        GetComponent<AudioSource>().Play();
    }
    public void ShowStat()
    {
        
        statMenu.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    public void HideStat()
    {
        animator.SetInteger("setState", 0);
        statMenu.SetActive(false);
        GetComponent<AudioSource>().Play();
    }

    public void AppQuit()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
        Debug.Log("Quit");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        GetComponent<AudioSource>().Play();
    }

}
