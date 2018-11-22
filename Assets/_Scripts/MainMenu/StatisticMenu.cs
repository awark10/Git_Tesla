using UnityEngine;

public class StatisticMenu : MonoBehaviour {
    public Animator animator;
    public GameObject hideObj1;
    public GameObject hideObj2;
    
    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("statstate", 0);
    }
    public void IdleStay()
    {
        animator.SetInteger("statstate", 0);
        
    }
    public void OpenedStay()
    {
        animator.SetInteger("statstate", 2);
        hideObj1.SetActive(false);
        hideObj2.SetActive(false);
       
    }
    public void MovingOpen()
    {
        animator.SetInteger("statstate", 2);
        hideObj1.SetActive(false);
        hideObj2.SetActive(false);
       
    }
    public void MovingClose()
    {
        animator.SetInteger("statstate", 3);
       
        hideObj1.SetActive(true);
        hideObj2.SetActive(true);
    }
   
}
