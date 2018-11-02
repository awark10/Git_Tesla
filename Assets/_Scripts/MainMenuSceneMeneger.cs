using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneMeneger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadTimeGame()
    {
      SceneManager.LoadScene(2);
    }
    public void LoadEarthGame()
    {
       SceneManager.LoadScene(1);
       
    }

}
