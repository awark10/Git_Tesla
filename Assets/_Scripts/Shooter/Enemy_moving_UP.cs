using UnityEngine;

public class Enemy_moving_UP : MonoBehaviour {

    public float speed;
   
    void Update()
    {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.localScale -= (new Vector3(0.2f, 0.2f, 0.2f) * speed * Time.deltaTime);


    }
}
