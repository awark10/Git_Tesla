using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class _LevelController : MonoBehaviour {

    //public GameObject pauseMenu;
    

    public float fulltime;
    
   

    ThinkGearController controller;

    public Texture2D[] signalIcons;
    private int PoorSignal = 200;
    private float indexSignalIcons = 1;
    private bool enableAnimation = false;
    private float animationInterval = 0.06f;

    
    void Start () {

        controller = GameObject.Find("ThinkGear").GetComponent<ThinkGearController>();
        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        
    }

        
    void FixedUpdate () {
       
        if (enableAnimation)
        {
            if (indexSignalIcons >= 4.8)
            {
                indexSignalIcons = 2;
            }
            indexSignalIcons += animationInterval;
        }

    }


    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        //GUILayout.Label("Demo App");
        GUILayout.Space(Screen.width - 30);
        GUILayout.Label(signalIcons[(int)indexSignalIcons]);
        GUILayout.EndHorizontal();
    }

    void OnUpdatePoorSignal(int value)
    {
        PoorSignal = value;
        if (value == 0)
        {
            indexSignalIcons = 0;
            enableAnimation = false;
        }
        else if (value == 200)
        {
            indexSignalIcons = 1;
            enableAnimation = false;
        }
        else if (!enableAnimation)
        {
            indexSignalIcons = 2;
            enableAnimation = true;
        }
    }
}
