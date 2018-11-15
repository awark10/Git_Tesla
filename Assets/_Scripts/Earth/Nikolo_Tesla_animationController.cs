using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nikolo_Tesla_animationController : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("nikoloState", 0);

    }
	
    public void Moving()
    {
        animator.SetInteger("nikoloState", 1);
    }
    public void IdleStay()
    {
        animator.SetInteger("nikoloState", 0);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
