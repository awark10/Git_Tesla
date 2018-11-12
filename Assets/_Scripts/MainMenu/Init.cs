using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;
	    
	// Use this for initialization
	void Start () {
		
		if (!GAME.Instance.isDemo)
		{ 
			if (!GAME.Instance.isConnected) 
			{
				connectMenu.SetActive (true);
				gamesMenus.SetActive (false);
			} 
			else
			{
				connectMenu.SetActive (false);
				gamesMenus.SetActive (true);
			}
        }
        else
        {
            connectMenu.SetActive(false);
            gamesMenus.SetActive(true);
        }
    }
}
