using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class SpellProjectile : MonoBehaviour {

	public bool regeneratingMana;
	public bool manaRegeneration;
	public GameObject Fireflies;
	public Image manaSlider;
	public int currentMana;
	public int maxMana = 100;
	public Text manaText;
	CharacterStats myStats;
	private Vector3 hitPosition;
	public PlayerMotor motor;
	public EnemySpellCollision spellPower;
	public GameObject rightHand;
	public GameObject leftHand;
	public Vector3 rightHandPosition;
	public Vector3 leftHandPosition;
	public LayerMask enemyMask;
	public LayerMask groundMask;
	CharacterStats opponentStats;

	public ParticleSystem Spell1;
	public ParticleSystem Spell2;
	public ParticleSystem Spell3;
	public ParticleSystem Spell4;
	public ParticleSystem Spell41;
	public ParticleSystem Spell42;
	public ParticleSystem Spell5;

	public GameObject Spell1Object;
	public GameObject Spell2Object;
	public GameObject Spell3Object;
	public GameObject Spell4Object1;
	public GameObject Spell4Object2;
	public GameObject Spell4Object3;
	public GameObject Spell5Object;

	public ParticleSystem Ability1;
	public ParticleSystem Ability2Right;
	public ParticleSystem Ability2Left;
	public ParticleSystem Ability3;
	public ParticleSystem Ability4Start;
	public ParticleSystem Ability4End;
	public ParticleSystem Ability5;

	public GameObject Ability1Object;
	public GameObject Ability2ObjectRight;
	public GameObject Ability2ObjectLeft;
	public GameObject Ability3Object;
	public GameObject Ability4ObjectStart;
	public GameObject Ability4ObjectEnd;
	public GameObject Ability5Object;

	public float Spell1Cooldown = 2f;
	public float Spell2Cooldown = 2f;
	public float Spell3Cooldown = 2f;
	public float Spell4Cooldown = 2f;
	public float Spell5Cooldown = 2f;

	public float Ability1Cooldown = 2f;
	public float Ability2Cooldown = 2f;
	public float Ability3Cooldown = 2f;
	public float Ability4Cooldown = 2f;
	public float Ability5Cooldown = 2f;

	public int Spell1ManaCost = 10;
	public int Spell2ManaCost = 10;
	public int Spell3ManaCost = 10;
	public int Spell4ManaCost = 10;
	public int Spell5ManaCost = 10;

	public int Ability1ManaCost = 10;
	public int Ability2ManaCost = 10;
	public int Ability3ManaCost = 10;
	public int Ability4ManaCost = 10;
	public int Ability5ManaCost = 10;

	private float Spell1StartTime;
	private float Spell2StartTime;
	private float Spell3StartTime;
	private float Spell4StartTime;
	private float Spell5StartTime;

	private float Ability1StartTime;
	private float Ability2StartTime;
	private float Ability3StartTime;
	private float Ability4StartTime;
	private float Ability5StartTime;

	void Start () {
		currentMana = maxMana;
		myStats = transform.GetComponent<CharacterStats> ();
	}

	void Update(){
		float manaPercent = (float)currentMana / maxMana;
		manaSlider.fillAmount = manaPercent;
		manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
		currentMana = Mathf.Clamp (currentMana, 0, maxMana);
		if (currentMana < maxMana) {
			manaRegeneration = true;
			if (regeneratingMana == false) {
				StartCoroutine (ManaRegeneration ());
			}
		} 
		if (currentMana == maxMana) {
			regeneratingMana = false;
			manaRegeneration = false;
		}
		rightHandPosition = rightHand.transform.position;
		leftHandPosition = leftHand.transform.position;

		if (Input.GetKeyDown(KeyCode.Q)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Spell1ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, enemyMask) && Time.time >= Spell1StartTime + Spell1Cooldown) {
					currentMana -= Spell1ManaCost;
					Spell1.transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
					Spell1StartTime = Time.time;
					Spell1Object.gameObject.SetActive (true);
					hitPosition = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 3, hit.collider.transform.position.z);
					Spell1.transform.LookAt (hitPosition);
					Spell1.Play ();
				}
			}
		}
		Spell1.transform.Translate (Vector3.forward * Time.deltaTime * 20f);

		if (Input.GetKeyDown(KeyCode.W)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Spell2ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, enemyMask) && Time.time >= Spell2StartTime + Spell2Cooldown) {
					currentMana -= Spell2ManaCost;
					Spell2.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
					Spell2StartTime = Time.time;
					Spell2Object.gameObject.SetActive (true);
					hitPosition = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z);
					Spell2.transform.LookAt (hitPosition);
					Spell2.Play ();
				}
			}
		}
		Spell2.transform.Translate (Vector3.forward * Time.deltaTime * 10f);
		if (Input.GetKeyDown(KeyCode.E)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Spell3ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, enemyMask) && Time.time >= Spell3StartTime + Spell3Cooldown) {
					currentMana -= Spell3ManaCost;
					Spell3Object.transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
					Spell3StartTime = Time.time;
					Spell3.gameObject.SetActive (true);
					hitPosition = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 3, hit.collider.transform.position.z);
					Spell3Object.transform.LookAt (hitPosition);
					Spell3.Play ();
				}
			}
		}
		Spell3Object.transform.Translate (Vector3.forward * Time.deltaTime * 15f);
		if (Input.GetKeyDown(KeyCode.R)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Spell4ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, enemyMask) && Time.time >= Spell4StartTime + Spell4Cooldown) {
					currentMana -= Spell4ManaCost;
					Spell4StartTime = Time.time;
					hitPosition = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 3, hit.collider.transform.position.z);
					StartCoroutine (Spell4Shards (hitPosition));
				}
			}
		}
		Spell4Object1.transform.Translate (Vector3.forward * Time.deltaTime * 20f);
		Spell4Object2.transform.Translate (Vector3.forward * Time.deltaTime * 20f);
		Spell4Object3.transform.Translate (Vector3.forward * Time.deltaTime * 20f);
		if (Input.GetKeyDown(KeyCode.T)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Spell5ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, enemyMask) && Time.time >= Spell5StartTime + Spell5Cooldown) {
					currentMana -= Spell5ManaCost;
					Spell5StartTime = Time.time;
					Spell5Object.transform.position = new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z);
					Spell5.gameObject.SetActive (true);
					hitPosition = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 3, hit.collider.transform.position.z);
					Spell5Object.transform.LookAt (hitPosition);
					Spell5.Play ();
				}
			}
		}
		Spell5Object.transform.Translate (Vector3.forward * Time.deltaTime * 15f);
		Spell5Object.transform.Rotate (0, 0f, 1000f * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.A)){
			if (currentMana >= Ability1ManaCost) {
				if (Time.time >= Ability1StartTime + Ability1Cooldown) {
					currentMana -= Ability1ManaCost;
					Ability1StartTime = Time.time;
					myStats.TakeDamage (-20);
					Ability1.Play ();
				}
			}
		}
		Ability1Object.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		if (Input.GetKeyDown(KeyCode.S)){
			if (currentMana >= Ability2ManaCost) {
				if (Time.time >= Ability2StartTime + Ability2Cooldown) {
					currentMana -= Ability2ManaCost;
					Ability2StartTime = Time.time;
					Ability2Right.Play ();
					Ability2Left.Play ();
					myStats.damage.AddModifier (10);
					StartCoroutine (BloodlustCD ());
				}
			}
		}
		Ability2ObjectRight.transform.position = rightHandPosition;
		Ability2ObjectLeft.transform.position = leftHandPosition;
		if (Input.GetKeyDown(KeyCode.D)){
			if (currentMana >= Ability3ManaCost) {
				if (Time.time >= Ability3StartTime + Ability3Cooldown) {
					currentMana -= Ability3ManaCost;
					Ability3StartTime = Time.time;
					spellPower.spellPower += 20;
					Ability3.Play ();
					StartCoroutine (SpellPowerCD ());
				}
			}
		}
		Ability3Object.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		if (Input.GetKeyDown(KeyCode.F)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (currentMana >= Ability4ManaCost) {
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, groundMask) && Time.time >= Ability4StartTime + Ability4Cooldown) {
					currentMana -= Ability4ManaCost;
					Ability4StartTime = Time.time;
					Ability4ObjectStart.transform.position = new Vector3 (transform.position.x, transform.position.y + 2, transform.position.z);
					hitPosition = new Vector3 (hit.point.x, hit.point.y + 2, hit.point.z);
					Ability4Start.Play ();
					Ability4ObjectEnd.transform.position = hitPosition;
					Ability4End.Play ();
					transform.position = hitPosition;
					motor.MoveToPoint (hit.point);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.G)){
			if (currentMana >= Ability1ManaCost) {
				if (Time.time >= Ability5StartTime + Ability5Cooldown) {
					currentMana -= Ability5ManaCost;
					Ability5StartTime = Time.time;
					Ability5.Play ();
					myStats.armor.AddModifier (10);
					StartCoroutine (ShieldCD ());
				}
			}
		}
		Ability5Object.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
	}	
	IEnumerator ShieldCD(){
		yield return new WaitForSeconds (5f);
		Ability5.Stop ();
		myStats.armor.RemoveModifier (10);
	}
		
	IEnumerator SpellPowerCD(){
		yield return new WaitForSeconds (5f);
		Ability3.Stop ();
		spellPower.spellPower -= 20;
	}
	IEnumerator BloodlustCD(){
		yield return new WaitForSeconds (5f);
		Ability2Right.Stop ();
		Ability2Left.Stop ();
		myStats.damage.RemoveModifier (10);
	}
	IEnumerator Spell4Shards(Vector3 hitPosition){
		Spell4Object1.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
		Spell4Object1.transform.LookAt(hitPosition);
		Spell4.gameObject.SetActive (true);
		Spell4.Play ();
		yield return new WaitForSeconds (0.5f);
		Spell4Object2.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
		Spell4Object2.transform.LookAt(hitPosition);
		Spell41.gameObject.SetActive (true);
		Spell41.Play ();
		yield return new WaitForSeconds (0.5f);
		Spell4Object3.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
		Spell4Object3.transform.LookAt(hitPosition);
		Spell42.gameObject.SetActive (true);
		Spell42.Play ();
	}
	IEnumerator ManaRegeneration(){
		regeneratingMana = true;
		while (manaRegeneration) {
			yield return new WaitForSeconds (1f);
			currentMana += 1;
		}
	}
}
