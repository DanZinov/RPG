using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keeps track of enemy stats, loosing health and dying. */

public class EnemyStats : CharacterStats {

	public ParticleSystem deathAnimation;
	public GoldManager gold;
	public int goldAmount;
	public override void Die()
	{
		base.Die();
		gold.gold += goldAmount;
		deathAnimation.Play();
		Destroy(gameObject);
	}

	void Update(){
		deathAnimation.transform.position = gameObject.transform.position;
	}
}
