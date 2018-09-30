using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour {

	// Health
	public Image healthSlider;
	public bool regeneratingHealth;
	public bool healthRegeneration;
	public Text healthText;
	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat damage;
	public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

	// Set current health to max health
	// when starting the game.
	void Awake ()
	{
		currentHealth = maxHealth;
	}
	void Update(){
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
		if (currentHealth < maxHealth) {
			healthRegeneration = true;
			if (regeneratingHealth == false) {
				StartCoroutine (HealthRegeneration ());
			}
		} 
		if (currentHealth == maxHealth) {
			regeneratingHealth = false;
			healthRegeneration = false;
		}
		healthText.text = currentHealth.ToString () + "/" + maxHealth.ToString ();
		float healthPercent = (float)currentHealth / maxHealth;
		healthSlider.fillAmount = healthPercent;
	}
	// Damage the character
	public void TakeDamage (int damage)
	{
		//damage = Mathf.Clamp(damage, 0, int.MaxValue);
		if (damage <= armor.GetValue () && damage > 0) {
			damage = 0;
		} else {
			damage -= armor.GetValue();
		}
		// Damage the character
		currentHealth -= damage;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
		Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}
	IEnumerator HealthRegeneration(){
		regeneratingHealth = true;
		while (healthRegeneration) {
			yield return new WaitForSeconds (1f);
			currentHealth += 1;
		}
	}

	public virtual void Die ()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
	}
}
