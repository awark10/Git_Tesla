using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_Animation : MonoBehaviour {

   public Animator teslaAnim;
    public GameObject connectMenu;
    public AudioSource clipOne;
    public AudioSource clipTwo;
    
    void Start () {
        teslaAnim = GetComponent<Animator>();
        teslaAnim.SetInteger("tesla",1);

    }
	public void HideConnect()
    {
        connectMenu.SetActive(false);
    }

    public void TeslaShowAnimation()
    {
        teslaAnim.SetInteger("tesla", 2);
       
    }
    public void playFatility()
    {
        clipOne.Play();
    }
    public void playTwo()
    {
        clipTwo.Play();
    }
    public void TeslaStopAnimation()
    {
        teslaAnim.SetInteger("tesla", 1);
      //  clipTwo.Play();
    }
   
    
}
