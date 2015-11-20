using UnityEngine;
using System.Collections;
using InControl; 

public class InputHandler : MonoBehaviour {

	// Which gameObject to route input to
	public BaseInputHandler handler;
	private InputDevice device = InputManager.ActiveDevice;
 

	// Use this for initialization
	void Start () {
		// Default to whichever party Duke is in 
		// We can guarantee that Duke will always be in a party
		// as he is the first character
		
		// Though if we use this for menus (we should!) 
		// It should default to the start menu, then 
		// give control to Duke
	}
	
	// Update is called once per frame
	void Update () {
		/*
		We're going to assume that the player has something similar to an 
		Xbox 360 controller for now
		http://www.gallantgames.com/assets/InControl/Controller-ebf136616887bd7fe67bc086d8e672716ddd6e1c8194f39d7b4fb908b1d0b86d.png
		*/
		
		if (InputManager.ActiveDevice.Action1.WasPressed)
		{
    		handler.ActionButton();
		}
		
		if(InputManager.ActiveDevice.Action2.WasPressed)
		{
			handler.CancelButton(); 
		}
		
		if(InputManager.ActiveDevice.Action3.WasPressed)
		{
			handler.MenuButton(); 
			//  handler.CustomActionX(); 
		}		
		if(InputManager.ActiveDevice.Action4.WasPressed)
		{
			handler.CustomActionY(); 
		}
		//  if(InputManager.ActiveDevice.Command)
		//  {
		//  	handler.MenuButton(); 
		//  }
		
		var leftTilt = Vector3.zero;
        leftTilt.x = InputManager.ActiveDevice.GetControl(InputControlType.LeftStickX).Value;
        leftTilt.z = InputManager.ActiveDevice.GetControl(InputControlType.LeftStickY).Value;
		if(leftTilt != Vector3.zero)
		{
			handler.LeftStick(leftTilt);
		} 
		
		
		var rightTilt = Vector3.zero;
        rightTilt.x = InputManager.ActiveDevice.GetControl(InputControlType.RightStickX).Value;
        rightTilt.z = InputManager.ActiveDevice.GetControl(InputControlType.RightStickY).Value;
		if(rightTilt != Vector3.zero)
		{
			// Not sure what this might be used for. camera panning? no rotation here...
			handler.RightStick(rightTilt);
		}


		// Let's try to use shoulder buttons mostly for switching "horizontally" between things
		// For example, using shoulder buttons to switch between parties on the map
		// or switching between which player can action in a battle
		
		if(InputManager.ActiveDevice.LeftTrigger.WasPressed || InputManager.ActiveDevice.LeftBumper.WasPressed)
		{
			handler.LeftShoulder(); 
		}
		if(InputManager.ActiveDevice.RightTrigger.WasPressed || InputManager.ActiveDevice.RightBumper.WasPressed)
		{
			handler.RightShoulder(); 
		}
	}
	
	public void SetHandler(BaseInputHandler ibh)
	{
		handler = ibh;
	}
}
