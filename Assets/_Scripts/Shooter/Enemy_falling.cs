using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_falling : MonoBehaviour {
    public float speed;
    
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //  collision.GetComponent<Tower>().GetDamage(damage * damageCoeficient);
            Destroy(gameObject);
        }
    }
}
