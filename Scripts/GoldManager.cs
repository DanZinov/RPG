using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour {

	public Text goldDisplay;
	public int gold;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		goldDisplay.text = gold.ToString ();
	}
}
