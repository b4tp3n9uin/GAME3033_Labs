using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool CursorActive = true;

    void EnableCursor(bool enable)
    {
        if (enable)
        {
            CursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            CursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnEnable()
    {
        AppEvents.MouseCursorEnabled += EnableCursor;
    }

    private void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;
    }
}
