using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeMenu_Controller : MonoBehaviour {
   
    public GameObject swipeMenu;
    public RectTransform rectTransform;
    public GameObject closeSettingsBTN;
    public GameObject hideButton;
    public AudioClip clickSound;
    private Vector2 startPos = new Vector2(-600, 0f);
    private Vector2 target= new Vector2(0, 0f);
    private Vector2 tochStart;
    private bool isScrolling;
    public float speed;
    public bool opened;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = clickSound;
        opened = false;
        rectTransform.anchoredPosition = startPos;
        
    }
    
    public void IdleStay()
    {
        opened = false;
    }
    public void OpenedState()
    {
        opened = true;
    }
    public void MovClose()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, startPos, speed * Time.deltaTime);
        
            Time.timeScale = 1;
    }
    public void MovOpen()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, target, speed * Time.deltaTime);
        if (rectTransform.anchoredPosition == target)
            Time.timeScale = 0.01f;
    }
    public void ChangeState()
    {
        opened = !opened;
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
     public void FixedUpdate()
     {
         if (!opened)
         {
            MovClose();
        }
         else
         {
            MovOpen();
         }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState();
        }
        if (Input.touchCount > 0)
         {
             Touch touch = Input.touches[0];

             switch (touch.phase)
             {
                 case TouchPhase.Began: tochStart = touch.position; break;
                 case TouchPhase.Moved:
                     //swipe horizontal?
                     if (touch.position.x - tochStart.x > 20)
                         OpenedState();
                     if (touch.position.x - tochStart.x < -20)
                         IdleStay();
                     break;
             }
         }
    }

}

