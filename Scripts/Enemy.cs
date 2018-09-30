using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	CharacterStats myStats;

	void Start ()
	{
		myStats = GetComponent<CharacterStats>();
	}

	public override void Interact()
	{
		base.Interact();
		CharacterCombat playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterCombat>();
		if (playerCombat != null)
		{
			playerCombat.Attack(myStats);
		}
	}

}
