﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earth_Aura : MonoBehaviour {

	public SpriteRenderer auraSprite;
	private float x;

	[Header("Received Values")]
	[Range(0, 100)]
	public int Attention = 0;
	[Range(0, 100)]
	public int Meditation = 0;

	// Update is called once per frame
	void Update () {

		Meditation = GDATA.Instance.Meditation;
		Attention  = GDATA.Instance.Attention;

		if (Meditation == Attention)

			x = Mathf.MoveTowards(x, 50, Time.deltaTime * 100);

		else if (Meditation > Attention)

			x = Mathf.MoveTowards(x, 50 - Meditation / 2, Time.deltaTime * 100);

		else if (Attention > Meditation)

			x = Mathf.MoveTowards(x, 50 + Attention / 2, Time.deltaTime * 100);

		auraSprite.color = Color.Lerp(Color.green, Color.red, x / 100);
	}
}
