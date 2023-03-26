using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.InputSystem;

public class UsingState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse != null)
        {
            Debug.LogFormat("mouse: scroll:{0}, left:{1}", mouse.scroll.ReadValue(), mouse.leftButton.isPressed);
        }

        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            var allPressedKeys = keyboard.allKeys.Where((k) => k.isPressed);
            if (allPressedKeys.Count() > 0)
            {
                Debug.LogFormat("keyboard: pressed:{0}", string.Join(",", allPressedKeys));
            }
        }

        Gamepad gamepad = Gamepad.current;
        if (gamepad != null)
        {
            Debug.LogFormat("gamepad: leftStick:{0}, leftTrigger", gamepad.leftStick.ReadValue(), gamepad.leftTrigger.ReadValue());
        }
    }
}
