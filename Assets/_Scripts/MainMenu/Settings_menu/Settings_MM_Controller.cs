using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_MM_Controller : MonoBehaviour {
    public Animator animator;
    public GameObject settingsMenu;
    public GameObject gamesMenu;
    public GameObject connectMenu;
    public GameObject aboutMenu;
    public GameObject closeSettingsBTN;
    public GameObject profileUpButton;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("setState", 0);
        aboutMenu.SetActive(false);
    }

    public void IdleStay()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
        profileUpButton.SetActive(true);
        //aboutMenu.SetActive(false);
    }



    public void OpenedStay()
    {
        animator.SetInteger("setState", 2);
        closeSettingsBTN.SetActive(true);
        profileUpButton.SetActive(false);
    }
    public void MovingOpen()
    {
        animator.SetInteger("setState", 2);
        closeSettingsBTN.SetActive(true);
        profileUpButton.SetActive(false);
    }
    public void MovingClose()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
        profileUpButton.SetActive(true);
    }

    public void Connection()
    {
        animator.SetInteger("setState", 0);
        closeSettingsBTN.SetActive(false);
        gamesMenu.SetActive(false);
        connectMenu.SetActive(true);
    }
    
    public void ShowAbout()
    {
        aboutMenu.SetActive(true);
    }
    public void HideAbout()
    {
        aboutMenu.SetActive(false);
    }

    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
	
}
