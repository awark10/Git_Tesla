using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeMenu_Controller : MonoBehaviour {
   // public Animator animator;
    public GameObject swipeMenu;
    public RectTransform rectTransform;
   // public GameObject aboutMenu;
  //  public GameObject statMenu;
    public GameObject closeSettingsBTN;
    public GameObject hideButton;
    public AudioClip clickSound;
    //public ScrollRect scrollRect;
  //  private Image image;
    private Vector2 startPos;
    private Vector2 target;
    private bool isScrolling;
    public float speed;
    public bool opened;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = clickSound;
        opened = false;
        rectTransform.anchoredPosition = new Vector2(-300, 44.75f);
        
    }
    
    public void IdleStay()
    {
        
        opened = false;
       // rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(-300, 44.75f), speed * Time.deltaTime);

    }
    public void OpenedState()
    {
        opened = true;
      //  rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(300, 44.75f), speed * Time.deltaTime);
    }
    public void MovOpen()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(-300, 44.75f), speed * Time.deltaTime);
    }
    public void MovClose()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(300, 44.75f), speed * Time.deltaTime);
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
         if (!opened)
         {
            MovOpen();
         }
         else
         {
            MovClose();
         }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began: startPos = touch.position; break;
                case TouchPhase.Moved:
                    //swipe horizontal?
                    if ((touch.position.x - startPos.x) > 16 || (touch.position.x - startPos.x) < -16)
                    {
                        if (touch.position.x - startPos.x > 70)
                            OpenedState();
                        
                        if (touch.position.x - startPos.x < -30)
                            IdleStay();
                    }
                    
                    break;
            }
        }
    }
    
}

