using UnityEngine;
using System.Collections;

public abstract class BaseInputHandler {
	abstract public void ActionButton(); // The A button on an Xbox Controller
	abstract public void CancelButton(); // The B button on an Xbox Controller
	abstract public void CustomActionX(); // The X button on an Xbox Controller
	abstract public void CustomActionY(); // The Y button on an Xbox Controller
	abstract public void MenuButton(); // The start button, 

	abstract public void LeftStick(Vector3 val);
	abstract public void RightStick(Vector3 val);


	// Let's try to use shoulder buttons mostly for switching horizontally between things
	// For example, using shoulder buttons to switch between parties on the map
	// or switching between which player can action in a battle
	
	abstract public void LeftShoulder(); 
	//  abstract public void LeftBumper();
	//  abstract public void LeftTrigger(); 

	abstract public void RightShoulder(); 	
	//  abstract public void RightBumper();  
	//  abstract public void RightTrigger(); 
}
