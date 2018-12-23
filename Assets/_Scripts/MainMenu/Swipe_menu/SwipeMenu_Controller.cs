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
    private Vector2 startPos;
    private Vector2 target;
    private bool isScrolling;
    public float speed;
    public bool opened;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = clickSound;
        opened = false;
        rectTransform.anchoredPosition = new Vector2(-300, 0f);
        
    }
    
    public void IdleStay()
    {
        opened = false;
    }
    public void OpenedState()
    {
        opened = true;
    }
    public void MovOpen()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(-300, 0), speed * Time.deltaTime);
    }
    public void MovClose()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(300, 0f), speed * Time.deltaTime);
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
    
    }
    
}

