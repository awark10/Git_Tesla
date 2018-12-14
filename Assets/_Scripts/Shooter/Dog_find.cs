using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_find : MonoBehaviour {
    public float timer;
    private float times;
	// Use this for initialization
	void Start () {
        times = 0;
    }
	
	// Update is called once per frame
	void Update () {
        times += Time.deltaTime;
        if (times > timer) Destroy(gameObject);
	}
}
