using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour
{

    public Texture2D cursorImageBasic;
    public Vector2 normalCursorHotspot;

    public Texture2D cursorImageHover;
    public Vector2 hoverCursorHotspot;

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorImageHover, hoverCursorHotspot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorImageBasic, normalCursorHotspot, CursorMode.Auto);
    }

}
