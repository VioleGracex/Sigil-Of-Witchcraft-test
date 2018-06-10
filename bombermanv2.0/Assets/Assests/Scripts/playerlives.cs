using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlives : MonoBehaviour {
	public GameObject player;
	public int playerhearts=2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void playerheart () 
	{
		if (player.activeSelf == false) 
		{
			playerhearts -= 1;
			//trigger respawn anim
			if(playerhearts>0)
			{
				player.SetActive(true);
			}

		}
	}
}
