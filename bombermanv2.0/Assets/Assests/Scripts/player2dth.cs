using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2dth : MonoBehaviour {

	public GameObject Exploision;
	public int playerhearts;
	public float Barrierdura=5f;
	public GameObject barrier;
	public CircleCollider2D collider1;
	public void Barrierheart()
	{
		Barrierdura = 5f;
		//trigger barrier breaking
		barrier.SetActive (true);


	}
	//OnTriggerStay2D
	void  OnTriggerEnter2D (Collider2D Exploision)
	{ 
		
		//Debug.Log ("dth"+Exploision.tag+"name"+Exploision.name);

		//if (name == collider1.name) 
		//{
			if (Exploision.gameObject.name == "Exploision(Clone)") 
			{
				if (barrier.activeSelf == false) 
				{
					//rigger spawn anim
					playerhearts -= 1;
					if (playerhearts <= 0)
					{
						deathisreal ();
						FindObjectOfType<GameEnd> ().whodied (gameObject.name);
					}
				} 
				else
				{
					Barrierdura = 0f;	
				}
			}
		//}

	}
	/*void OnTriggerEnter2D(Collider2D Exploision)
	{ 
	//Debug.Log ("dth"+Exploision.tag+"name"+Exploision.name);
		if (Exploision.gameObject.name == "Exploision(Clone)") 
		{
			if (barrier.activeSelf == false) 
			{
				//rigger spawn anim
				playerhearts -= 1;
				if (playerhearts <= 0) {
					deathisreal ();
					FindObjectOfType<GameEnd> ().whodied (gameObject.name);
				}
			}
			else
			{
				Barrierdura = 0f;	
			}
		}
	}
		*/

		//Destroy (gameObject);

	void deathisreal()
	{
		//trigger dth anim
		gameObject.SetActive (false);
		FindObjectOfType<bot> ().resetonetime ();
	}
	void Update () 
	{
		if (barrier.activeSelf==true) 
		{
			Barrierdura -= Time.deltaTime;
		}
		if (Barrierdura <= 0f)
		{
			barrier.SetActive (false);
		}


	}
}
