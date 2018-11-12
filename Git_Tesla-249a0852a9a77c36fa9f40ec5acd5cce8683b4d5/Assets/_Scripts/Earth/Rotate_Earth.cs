using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Earth : MonoBehaviour {
    public float planetRotSpeed = 1.0f;
    public Transform planet;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        planet.Rotate(new Vector3(0, planetRotSpeed * Time.deltaTime, 0));
    }
}
