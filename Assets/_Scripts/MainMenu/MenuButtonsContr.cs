using UnityEngine;

public class MenuButtonsContr : MonoBehaviour {

    public RectTransform rectTransform;

    public void Start()
    {
        rectTransform.anchoredPosition = new Vector2(0, 0);
    }

    public void Games()
    {
        rectTransform.anchoredPosition = new Vector2(0,0);
    }
    public void Profile()
    {
        rectTransform.anchoredPosition = new Vector2(-150, 0);
    }
    public void Course()
    {
        rectTransform.anchoredPosition = new Vector2(150, 0);
    }
}
