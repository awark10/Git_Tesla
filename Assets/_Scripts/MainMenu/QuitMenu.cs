﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour {

    public RectTransform rectTransform;
    public float speed;
    public bool opened;
    public Vector3 close = new Vector3(0,0,0);
    public Vector3 open = new Vector3(1, 1, 1);
    // Use this for initialization
    void Start () {
        opened = false;
        rectTransform.localScale = close;
    }
    public void ChangeState()
    {
        opened = !opened;
    }

    public void OpenMenu()
    {
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, open, speed * Time.deltaTime);
        if (rectTransform.localScale == open)
            Time.timeScale = 0.01f;
    }
    public void CloseMenu()
    {
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, close, 5*speed * Time.deltaTime);
        Time.timeScale = 1f;
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        GetComponent<AudioSource>().Play();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState();
        }
        if (opened)
            OpenMenu();
        else CloseMenu();
    }
}