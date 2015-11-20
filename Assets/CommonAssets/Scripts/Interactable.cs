using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class Interactable : MonoBehaviour {

	private GameObject[] _players = null;
	public GameObject eventToActivate; 
	public float minDistanceToInteract; 

	// Use this for initialization
	void Start () {
		eventToActivate.active = false; 
		_players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject player in _players)
		{
			if(Vector3.Distance(player.transform.position, this.gameObject.transform.position) > minDistanceToInteract)
			{
				return; 
			}
			//  if(Action Button is Pressed)
			//  {
			//  	eventToActivate.active = true; 
			//  }
		}
	
	}
}
