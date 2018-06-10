using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class botpart3 : MonoBehaviour
{
	public bool foundbrick = false;	
	public bool bombisfound = false;
	public Tilemap tilemap;
	public Tile destructilbeTile;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player1prefab") 
		{
			//run
			FindObjectOfType<bombspawner2> ().activedabomb ();
			FindObjectOfType<bot> ().setbombexplodedtime ();
			FindObjectOfType<bot> ().player1foundo();
		}
		else
		{
		}
	
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = player.transform.position;
		transform.position = pos;
	}
}
