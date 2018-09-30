using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterStats))]
public class EnemySpellCollision : MonoBehaviour {
	CharacterStats myStats;
	public int spellPower;
	public GameObject Spell1Object;
	public GameObject Spell2Object;
	public GameObject Spell3Object;
	public GameObject Spell4Object1;
	public GameObject Spell4Object2;
	public GameObject Spell4Object3;
	public GameObject Spell5Object;
	public GameObject Spell1CollisionObject;
	public ParticleSystem Spell1CollisionPS;
	public GameObject Spell3CollisionObject;
	public ParticleSystem Spell3CollisionPS;
	public GameObject Spell4CollisionObject;
	public ParticleSystem Spell4CollisionPS;
	public GameObject Spell5CollisionObject;
	public ParticleSystem Spell5CollisionPS;
	// Use this for initialization
	void Start () {
		myStats = transform.GetComponent<CharacterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Spell1") {
			Spell1Object.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 0.5f);
			Spell1CollisionObject.transform.position = hitObject;
			Spell1CollisionPS.Play ();
			myStats.TakeDamage (20 + spellPower);
		}
		if (col.tag == "Spell2") {
			Spell2Object.gameObject.SetActive (false);
			myStats.TakeDamage (20 + spellPower);
		}
		if (col.tag == "Spell3") {
			Spell3Object.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 1f);
			Spell3CollisionObject.transform.position = hitObject;
			Spell3CollisionPS.Play ();
			myStats.TakeDamage (20 + spellPower);
		}
		if (col.tag == "Spell4") {
			Spell4Object1.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 1f);
			Spell4CollisionObject.transform.position = hitObject;
			Spell4CollisionPS.Play ();
			myStats.TakeDamage (5 + spellPower);
		}
		if (col.tag == "Spell4(1)") {
			Spell4Object2.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 1f);
			Spell4CollisionObject.transform.position = hitObject;
			Spell4CollisionPS.Play ();
			myStats.TakeDamage (5 + spellPower);
		}
		if (col.tag == "Spell4(2)") {
			Spell4Object3.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 1f);
			Spell4CollisionObject.transform.position = hitObject;
			Spell4CollisionPS.Play ();
			myStats.TakeDamage (5 + spellPower);
		}
		if (col.tag == "Spell5") {
			Spell5Object.gameObject.SetActive (false);
			Vector3 hitObject = new Vector3 (transform.position.x, transform.position.y + 3.5f, transform.position.z + 1f);
			Spell5CollisionObject.transform.position = hitObject;
			Spell5CollisionPS.Play ();
			myStats.TakeDamage (5 + spellPower);
		}
	}
}
