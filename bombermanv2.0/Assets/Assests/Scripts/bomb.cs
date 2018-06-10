using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bomb : MonoBehaviour {

	public float countdown=2f;
	public float colliderdelay=0.5f;
	public GameObject delayedcollider;

	// Update is called once per frame
	void Update () 
	{
		countdown = countdown - Time.deltaTime;
		colliderdelay -=Time.deltaTime;
		if (countdown <= 0f)
		{
			FindObjectOfType<mapdestroyer> ().Explode (transform.position);
			Destroy(gameObject);
		}
		if (colliderdelay <= 0f)
		{
			delayedcollider.SetActive (true);
		}
		
	}
}
