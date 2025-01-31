using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static event Action OnJoystickClick;

    public static void TriggerJoystickClick()
    {
        OnJoystickClick?.Invoke();
    }
}
