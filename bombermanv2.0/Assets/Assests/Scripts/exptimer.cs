using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exptimer : MonoBehaviour {

	// Use this for initialization
	public float count=0.1f;
	
	// Update is called once per frame
	void Update () {
		count = count - Time.deltaTime;
		if(count<=0f)
		{
			Destroy(gameObject);
		}

		/*GameObject[] killemall;
		killemall = GameObject.FindGameObjectsWithTag ("Exploision(Clone)");
		for ( int i =0 ; i < killemall.Length;i++)
		{
			Destroy (killemall [i].gameObject);
		}*/
	}
}
