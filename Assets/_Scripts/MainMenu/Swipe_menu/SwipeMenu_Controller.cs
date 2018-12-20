using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeMenu_Controller : MonoBehaviour {
    public Animator animator;
    public GameObject swipeMenu;
    public GameObject aboutMenu;
    public GameObject statMenu;
    public GameObject closeSettingsBTN;
    public GameObject hideButton;
    public AudioClip clickSound;
    public ScrollRect scrollRect;
    private Image image;
    private Vector2 startPos;
    private Vector2 target;
    private bool isScrolling;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = clickSound;
        animator = GetComponent<Animator>();
        animator.SetInteger("setState", 0);
        image = scrollRect.GetComponent<Image>();
    }

    public void IdleStay()
    {
        animator.SetInteger("setState", 0);
        hideButton.SetActive(true);
        image.raycastTarget = false;
    }
    public void OpenedState()
    {
        animator.SetInteger("setState", 1);
        hideButton.SetActive(false);
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

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began: startPos = touch.position; break;
                case TouchPhase.Moved:
                    //swipe horizontal?
                    if ((touch.position.x - startPos.x )> 10 || (touch.position.x - startPos.x) < -10) {
                        image.raycastTarget = true;
                        if (touch.position.x - startPos.x > 40)
                        OpenedState();
                    // target = new Vector2(tr.sizeDelta.x / 2, tr.anchoredPosition.y);//show menu
                    if (touch.position.x - startPos.x < -20)
                        IdleStay();
                    }
                    //target = new Vector2(-tr.sizeDelta.x / 2, tr.anchoredPosition.y);//hide menu
                    break;
            }
        }

}
}
