using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {

    public Slider progressSlider;
   
    public static int sceneId;
   
	// Use this for initialization
	void Start () {
        StartCoroutine("AsyncLoad");
	}
	
	IEnumerator AsyncLoad()
    {
       AsyncOperation loading = SceneManager.LoadSceneAsync(sceneId);
       
        while (!loading.isDone)
        {
            progressSlider.value = loading.progress;
           yield return null;
        }
    }
}
