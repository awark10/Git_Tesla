﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSceneMewneger : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
          SceneManager.LoadScene(0);
          MainMenuC.connectionDone = true;
        }
	}
}
