using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class PlayerHealth : MonoBehaviour {
	public Image healthSlider;

	void Start () {

		GetComponent<CharacterStats> ().OnHealthChanged += OnHealthChanged;
	}

	void LateUpdate(){
		healthSlider = GameObject.Find ("Player Health Bar").GetComponent<Image>();
	}
	void OnHealthChanged(int maxHealth, int currentHealth) {


		float healthPercent = (float)currentHealth / maxHealth;
		healthSlider.fillAmount = healthPercent;
	}
}
