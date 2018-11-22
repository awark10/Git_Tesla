using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileMenu : MonoBehaviour {
    public Animator animator;
    
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("proflmstate", 0);
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

}
