using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileMenu : MonoBehaviour {
    public Animator animator;
    public GameObject addProfileMenu;
    public AudioClip clickSound;

    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("proflmstate", 0);
        addProfileMenu.SetActive(false);
        GetComponent<AudioSource>().clip = clickSound;
    }
	

    public void IdleStay()
    {
        animator.SetInteger("proflmstate", 0);
    }
    public void OpenedStay()
    {
        animator.SetInteger("proflmstate", 4);
    }
    public void MovingOpen()
    {
        animator.SetInteger("proflmstate", 4);
        GetComponent<AudioSource>().Play();
    }
    public void MovingClose()
    {
        animator.SetInteger("proflmstate", 3);
        GetComponent<AudioSource>().Play();
    }
    public void ShowAddProfileMenu()
    {
        addProfileMenu.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
    public void HideAddProfileMenu()
    {
        addProfileMenu.SetActive(false);
        GetComponent<AudioSource>().Play();
    }

}
