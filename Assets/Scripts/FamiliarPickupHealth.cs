using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarPickupHealth : MonoBehaviour {

	public int healAmount = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "HealthPack")
		{
			GameObject.Find("Wizard").GetComponent<CollisionDamage>().health += healAmount;
		}
	}
}
