using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents
{
    public delegate void MouseCursorEnableEvent(bool enabld);

    public static event MouseCursorEnableEvent MouseCursorEnabled;

    public static void InvokeMouseCursorEnableEvent(bool enabled)
    {
        MouseCursorEnabled?.Invoke(enabled);
    }
}
