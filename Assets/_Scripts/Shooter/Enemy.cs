using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Duck_game duck_Game;
    public GameObject destructionVFX;
    public GameObject scoreVFX;
    public int score;
    // Use this for initialization
    void Start () {
        
    }

    private void OnEnable()
    {
        duck_Game = GameObject.Find("GameUI").GetComponent<Duck_game>();
        if (duck_Game == null)
            Debug.Log("Cant find duck_Game");
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   
            Destraction();
        }
    }
    public void Destraction()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Instantiate(scoreVFX, transform.position, Quaternion.identity);
        duck_Game.AddScore(score);
       // duck_Game.tmpDuckLilled++;
        Destroy(gameObject);
    }
}
