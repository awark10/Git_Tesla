using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Aura : MonoBehaviour {

	public SpriteRenderer auraSprite;
	private float x;

	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	// Use this for initialization
	void Start () {

		//auraSprite = aura.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

		Meditation = ThinkGearController.Instance.Meditation;
		Attention = ThinkGearController.Instance.Attention;
		
		if (Meditation == Attention)

			x = Mathf.MoveTowards(x, 50, Time.deltaTime * 100);

		else if (Meditation > Attention)

			x = Mathf.MoveTowards(x, 50 - Meditation / 2, Time.deltaTime * 100);

		else if (Attention > Meditation)

			x = Mathf.MoveTowards(x, 50 + Attention / 2, Time.deltaTime * 100);

		auraSprite.color = Color.Lerp(Color.green, Color.red, x / 100);
		// colorModule.color = Color.Lerp(Color.green, Color.red, x / 100);
	}
}
