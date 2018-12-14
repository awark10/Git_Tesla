using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_falling : MonoBehaviour {
    public float speed;
    public GameObject dog;
   // public GameObject dog2;
  //  Duck_game duck_Game;
   /* private void Start()
    {
        duck_Game = GameObject.Find("GameUI").GetComponent<Duck_game>();
    }*/
    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            //if (duck_Game.tmpDuckLilled == 1)
                DogOne();
          //  if (duck_Game.tmpDuckLilled !=1)
             //   DogTwo();
           
        }
    }

    public void DogOne()
    {
        Instantiate(dog, transform.position, Quaternion.identity);
        //duck_Game.tmpDuckLilled = 0;
        Destroy(gameObject);

    }
   /* public void DogTwo()
    {
        Instantiate(dog2, transform.position, Quaternion.identity);
        duck_Game.tmpDuckLilled = 0;
        Destroy(gameObject);
    }*/
}
