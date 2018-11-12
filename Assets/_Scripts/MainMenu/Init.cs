using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	public GameObject connectMenu;
	public GameObject gamesMenus;

	public GAME game;
    
	// Use this for initialization
	void Start () {
		
		if (!game.isDemo)
		{ 
			if (game.poorSignalStatus == 0) 
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
