using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum MouseButton { LeftButton, RightButton, MiddleButton, XButton4, XButton5, XButton6 }
public enum XBoxButton { A, B, X, Y, LB, RB, Back, Start, LeftAnalog, RightAnalog }
public static class InputUtil
{
    #region KEYBOARD
    public static bool IsHoldingKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
    #endregion
}

