﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGameTime : MonoBehaviour {
    public float gameTime;
    public Text  timeGameText;
    public int seconds, minutes;
   
    // Use this for initialization
    void Start () {
        timeGameText.text = minutes + ":" + seconds;
        gameTime = 0;
    }
	
	// Update is called once per frame
	void Update () {

    
            GameTime();

    }

    public void GameTime()
    {
        if (minutes < 0)
            timeGameText.text = 0 + ":0" + 0;
        else {
        gameTime += Time.deltaTime;
            if (gameTime >= 1.0f)
            {
                seconds--;
                gameTime -= 1.0f;
                if (seconds <= 0)
                {
                    seconds = 59;
                    minutes--;
                }
            }
            if (seconds < 10)
            {
                timeGameText.text = minutes + ":0" + seconds;
            }
            else
            {
                timeGameText.text = minutes + ":" + seconds;
            }

        }
    }
}