using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope_controller : MonoBehaviour {


    [System.Serializable]
    public class Borders
    {
        [Tooltip("offset from viewport borders for player's movement")]
        public float minXOffset = 0.3f, maxXOffset = 0.3f, minYOffset = 2.2f, maxYOffset = 0.3f;
        public float minX, maxX, minY, maxY;
    }

    [Range(-2.5f, 2.6f)]
    public float positionX;

    [Range(-2.7f, 4.5f)]
    public float positionY;

    Camera mainCamera;
    public Borders borders;
    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        ResizeBorders();
    }
	
    public void MovingScope()
    {
        if (Input.GetMouseButton(0)) //if mouse button was pressed       
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
            mousePosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, 15 * Time.deltaTime);
        }


#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 

        if (Input.touchCount == 1) // if there is a touch
        {
            Touch touch = Input.touches[0];
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  //calculating touch position in the world space
            touchPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, touchPosition, 15 * Time.deltaTime);
        }
#endif
        transform.position = new Vector3    //if 'Player' crossed the movement borders, returning him back 
            (
            Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
            Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
            0
            );
        positionX = transform.position.x;
        positionY = transform.position.y;
    }

    void ResizeBorders()
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
    // Update is called once per frame
    void Update () {
        MovingScope();
    }
}
