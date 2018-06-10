using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject player1win;
	public GameObject player2win;
	public GameObject player3win;
	public GameObject player4win;
	public GameObject Draw;
	public bool isplayer1alive=true;
	public bool isplayer2alive=true;
	public bool isplayer3alive=true;
	public bool isplayer4alive=true;
	public int rounds=1;

	public void whodied(string playername)
	{
		if (playername == player1.name) 
		{
			isplayer1alive = false;
		}
		if(playername==player2.name)
		{
			isplayer2alive = false;
		}
		if(playername==player3.name)
		{
			isplayer3alive = false;
		}
		if(playername==player4.name)
		{
			isplayer4alive = false;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (rounds > 0) 
		{
			if (isplayer1alive == false && isplayer2alive == false && isplayer3alive == false && isplayer4alive == false)
			{
				Debug.Log ("Draw");
				Draw.SetActive (true);
				rounds -=1 ;
			}
			if (isplayer1alive == true && isplayer2alive == false && isplayer3alive == false && isplayer4alive == false)
			{
				Debug.Log ("player1wins");
				player1win.SetActive (true);
				rounds -=1 ;
			}
			if (isplayer1alive == false && isplayer2alive == true && isplayer3alive == false && isplayer4alive == false) 
			{
				Debug.Log ("player2wins");
				player2win.SetActive (true);
				rounds -=1 ;
			}
			if (isplayer1alive == false && isplayer2alive == false && isplayer3alive == true && isplayer4alive == false)
			{
				Debug.Log ("playr3wins");
				player3win.SetActive (true);
				rounds -=1 ;
			}
			if (isplayer1alive == false && isplayer2alive == false && isplayer3alive == false && isplayer4alive == true) 
			{
				Debug.Log ("player4wins");
				player4win.SetActive (true);
				rounds -=1 ;
			}
		}
	}
}
