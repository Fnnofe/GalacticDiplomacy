using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseCursorSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorTexture;
    public Texture2D CursorSelectTexture;
    public Vector2 clickPositionOnTheTexture= new Vector2(0, 0);

    void Start()
    {
        Cursor.SetCursor(cursorTexture, clickPositionOnTheTexture, CursorMode.ForceSoftware);
    }

    public void OnMouseEnter()
    {
        if (this.GetComponent<IInteractable>() != null)
        {
            Cursor.SetCursor(CursorSelectTexture, clickPositionOnTheTexture, CursorMode.ForceSoftware);
        }
        Debug.Log("entered Object");

    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorTexture, clickPositionOnTheTexture, CursorMode.ForceSoftware);
        Debug.Log("Exit Object");


    }
}
