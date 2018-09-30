using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalPlayer : NetworkBehaviour{

	// Use this for initialization
	void Start () {
		if(isLocalPlayer){
			GetComponent<PlayerMotor>().enabled = true;
		}
	}
		
}
