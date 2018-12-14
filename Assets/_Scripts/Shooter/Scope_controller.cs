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

   
  public float positionX;
   public float positionY;
   // public float 
    Camera mainCamera;
    public Borders borders;
    // Use this for initialization
    void Start () {
        mainCamera = Camera.main;
        ResizeBorders();
    }
	
    public void MovingScope(float med, float att)
    {
        positionX = (att * mainCamera.pixelWidth) / 100;
        positionY = (med * mainCamera.pixelHeight) / 100;
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3 (positionX, positionY, 0));//new Vector3(positionX, positionY, 0);//calculating mouse position in the worldspace
            mousePosition.z = transform.position.z;
         //   Debug.Log(mousePosition);
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, 5 * Time.deltaTime);
      
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
       // MovingScope();
    }
}
