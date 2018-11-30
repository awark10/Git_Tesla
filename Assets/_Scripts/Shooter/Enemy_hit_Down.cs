using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_hit_Down : MonoBehaviour {

    public GameObject fallObject;
    public float timer;
    public float holdtime;  
    // Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer> holdtime)
        {
            Instantiate(fallObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
