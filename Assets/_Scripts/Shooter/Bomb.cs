using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    GameObject[] ducks;
    Enemy enemies;
    public GameObject destructionVFX;
    public float speed;
    public AudioClip bombSound;
    // Use this for initialization
    public void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Instantiate(destructionVFX, transform.position, Quaternion.identity);
        if (collision.tag == "Player")
        {
            ducks = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < ducks.Length; i++)
            {
               // enemies = ducks[i].GetComponent<Enemy>();
                //enemies.Destraction();
            }
                // Destroy(ducks[i]);
            Destroy(gameObject);
        }
    }
}
