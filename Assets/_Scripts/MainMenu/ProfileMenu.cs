using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileMenu : MonoBehaviour {
    public Animator animator;
    public GameObject addProfileMenu;

    
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("proflmstate", 0);
        addProfileMenu.SetActive(false);
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
    }
    public void MovingClose()
    {
        animator.SetInteger("proflmstate", 3);
    }
    public void ShowAddProfileMenu()
    {
        addProfileMenu.SetActive(true);
    }
    public void HideAddProfileMenu()
    {
        addProfileMenu.SetActive(false);
    }

}
