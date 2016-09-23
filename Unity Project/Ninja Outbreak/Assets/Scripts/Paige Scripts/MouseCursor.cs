using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{
    public Texture2D cursorImage;

    public int cursorWidth = 32;
    public int cursorHeight = 32;

    void Start()
    {
        Cursor.visible = false;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
    }
    public void Big()
    {
        cursorHeight = 45;
        cursorWidth = 45;
    }
    public void Normal()
    {
        cursorHeight = 32;
        cursorWidth = 32;
    }
}