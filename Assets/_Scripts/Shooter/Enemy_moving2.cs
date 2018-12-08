using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_moving2 : MonoBehaviour {
    public float speed;
    public float direction;
    public Vector3 rightMov ;
    public Vector3 leftMov;
    // Use this for initialization
    void Start()
    {
        direction = GetComponent<Transform>().localScale.x;
        rightMov = new Vector3(1, 1, 0);
     leftMov = new Vector3(-1, 1, 0);
}

    // Update is called once per frame
    void Update()
    {
        if (direction > 0)
            transform.Translate(rightMov * speed * Time.deltaTime);
        else transform.Translate(leftMov * speed * Time.deltaTime);
    }
}
