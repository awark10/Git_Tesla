using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject destructionVFX;
    // Use this for initialization
    void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //  collision.GetComponent<Tower>().GetDamage(damage * damageCoeficient);
            Destraction();
        }
    }
    public void Destraction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
