using UnityEngine;

public class Nikolo_Tesla_animationController : MonoBehaviour {

    public Animator animator;
   
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

}
