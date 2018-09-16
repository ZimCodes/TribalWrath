using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpidaLib.Util;
public static class MouseHandler {
    public static void UpdateCoordinate()
    {
        if (InputUtil.WasMouseBtnPressed(KeyCode.Mouse0))
        {
            Debug.Log("Mouse Position: " + Input.mousePosition);
        }
    }
}
