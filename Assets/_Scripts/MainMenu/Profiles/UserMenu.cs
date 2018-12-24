﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMenu : MonoBehaviour {

    public RectTransform rectTransform;
    private Vector2 startPos = new Vector2(0, -990f);
    private Vector2 target = new Vector2(0, 0f);
    public float speed;
    public bool opened;
    public AudioClip clickSound;
    // Use this for initialization
    void Start () {
        opened = false;

    }
	
    public void ChangeState()
    {
        opened = !opened;
    }

    public void OpenMenu()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, target, speed * Time.deltaTime);
    }
    public void CloseMenu()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, startPos, speed * Time.deltaTime);
    }
	
	void FixedUpdate () {

        if (opened)
            OpenMenu();
        else CloseMenu();

    }
}
