using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moving1 : MonoBehaviour {

    public float speed;
    public float direction;
    // Use this for initialization
    void Start () {
        direction = GetComponent<Transform>().localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction>0)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        else transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
