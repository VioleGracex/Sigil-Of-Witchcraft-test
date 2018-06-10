using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2PowerUps : MonoBehaviour {

	// Use this for initialization
	public float broomduration=2f;
	public int broomstart = 0;
	void OnTriggerEnter2D(Collider2D powerup)
	{ 
		//Debug.Log ("dth"+powerup.tag+"name"+powerup.name);
		if (powerup.name == "broompowerup(Clone)") 
		{
			//trigger broom anim
			broomduration = 2f;
			Destroy (powerup.gameObject);
			FindObjectOfType<bot> ().Doublethespeed ();
			broomstart = 1;
		}
		if (powerup.name == "PotPlusPowerup(Clone)") 
		{
			Destroy (powerup.gameObject);
			FindObjectOfType<bombspawner> ().bombplus ();
		}
		if (powerup.name == "StealthPotPowerup(Clone)") 
		{
			Destroy (powerup.gameObject);
			FindObjectOfType<bot> ().Stealthchar ();
		}
		if (powerup.name == "BarrierPowerup(Clone)") 
		{
			Destroy (powerup.gameObject);
			FindObjectOfType<player2dth> ().Barrierheart();
		}
	}
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (broomstart == 1) 
		{
			broomduration -= Time.deltaTime;
		}
		if (broomduration <= 0) 
		{
			FindObjectOfType<bot> ().powerupdurationend ();
			broomstart = 0;
		}
	}
}
