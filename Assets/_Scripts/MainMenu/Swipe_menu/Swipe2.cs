using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe2 : MonoBehaviour {
    public float moveSpeed = 600;

    private Vector2 startPos;
    private Vector2 target;
    // Use this for initialization
    void Start () {
        var tr = transform as RectTransform;
        target = tr.anchoredPosition;
    }
	
	// Update is called once per frame
	void Update () {
        var tr = transform as RectTransform;
        tr.anchoredPosition = Vector2.MoveTowards(tr.anchoredPosition, target, moveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {

        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case TouchPhase.Began: startPos = touch.position; break;
                case TouchPhase.Moved:
                    //swipe horizontal?
                    if (touch.position.x - startPos.x > 20)
                        target = new Vector2(tr.sizeDelta.x / 2, tr.anchoredPosition.y);//show menu
                    if (touch.position.x - startPos.x < -20)
                        target = new Vector2(-tr.sizeDelta.x / 2, tr.anchoredPosition.y);//hide menu
                    break;
            }
        }
    
}
}
