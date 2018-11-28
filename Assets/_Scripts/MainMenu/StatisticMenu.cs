using UnityEngine;

public class StatisticMenu : MonoBehaviour {
    public Animator animator;
    public GameObject hideObj1;
    public GameObject hideObj2;
    public AudioClip clickSound;

    void Start () {
        animator = GetComponent<Animator>();
        animator.SetInteger("statstate", 0);
        GetComponent<AudioSource>().clip = clickSound;
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
        GetComponent<AudioSource>().Play();

    }
    public void MovingClose()
    {
        animator.SetInteger("statstate", 0);
        GetComponent<AudioSource>().Play();
        hideObj1.SetActive(true);
        hideObj2.SetActive(true);
    }
   
}
