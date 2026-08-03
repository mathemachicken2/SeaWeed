using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public RectTransform cursorImage;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        cursorImage.position = Input.mousePosition;
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }
}