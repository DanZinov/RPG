using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapCamera : MonoBehaviour {
	public Image marker;
	public Transform player;

	void Update () {
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
		marker.transform.rotation = Quaternion.Euler (0, 0, 180 +(-1 * player.eulerAngles.y));	

	}
}
