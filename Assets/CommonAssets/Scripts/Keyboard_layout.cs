using System;
using System.Collections;
using UnityEngine;
using InControl;


namespace Keyboard_controls
{
    // This custom profile is enabled by adding it to the Custom Profiles list
    // on the InControlManager component, or you can attach it yourself like so:
    // InputManager.AttachDevice( new UnityInputDevice( "Keyboard_layout" ) );
    //
    public class Keyboard_layout : UnityInputDeviceProfile
    {
        public Keyboard_layout()
        {
            Name = "Keyboard";
            Meta = "A keyboard profile.";

            // This profile only works on desktops.
            SupportedPlatforms = new[]
            {
                "Windows",
                "Mac",
                "Linux"
            };

            Sensitivity = 1.0f;
            LowerDeadZone = 0.0f;
            UpperDeadZone = 1.0f;

            ButtonMappings = new[]
            {
                new InputControlMapping
                {
                    Handle = "Action Button",
                    Target = InputControlType.Action1,
                    Source = KeyCodeButton( KeyCode.Z )
                },

                new InputControlMapping
                {
                    Handle = "Cancel Button",
                    Target = InputControlType.Action2,
                    Source = KeyCodeButton( KeyCode.X )
                },

                new InputControlMapping
                {
                    Handle = "Menu Button",
                    Target = InputControlType.Action3,
                    Source = KeyCodeButton( KeyCode.A )
                },

                new InputControlMapping
                {
                    Handle = "Y Button",
                    Target = InputControlType.Action4,
                    Source = KeyCodeButton( KeyCode.S )
                },

                new InputControlMapping
                {
                    Handle = "Left Shoulder",
                    Target = InputControlType.LeftBumper,
                    Source = KeyCodeButton( KeyCode.LeftShift )
                },
                new InputControlMapping
                {
                    Handle = "Right Shoulder",
                    Target = InputControlType.RightBumper,
                    Source = KeyCodeButton( KeyCode.C )
                }
            };

            AnalogMappings = new[]
            {
                new InputControlMapping
                {
                    Handle = "Move X",
                    Target = InputControlType.LeftStickX,
                    // KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
                    Source = KeyCodeAxis( KeyCode.LeftArrow, KeyCode.RightArrow )
                },
                new InputControlMapping
                {
                    Handle = "Move Z",
                    Target = InputControlType.LeftStickY,
                    // Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
                    Source = KeyCodeAxis( KeyCode.DownArrow, KeyCode.UpArrow )
                }
            };
        }
    }
}