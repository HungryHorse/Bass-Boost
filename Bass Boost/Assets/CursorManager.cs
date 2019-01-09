using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    public bool shouldCursorBeVisable;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = shouldCursorBeVisable;
    }

    public void makeCursorVisable()
    {
        Cursor.visible = true;
    }
    public void makeCursorInvisable()
    {
        Cursor.visible = false;
    }
}
