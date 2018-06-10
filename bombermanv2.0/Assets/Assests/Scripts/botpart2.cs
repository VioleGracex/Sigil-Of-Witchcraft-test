using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class botpart2 : MonoBehaviour
{
	public bool foundbrick = false;	
	public bool bombisfound = false;
	public Tilemap tilemap;
	public Tile destructilbeTile;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D other)
	{

		Vector3 pos6 = other.transform.position;
		Vector3Int pos5 = tilemap.WorldToCell (pos6);
		Vector3 cellcenterpos3 = tilemap.GetCellCenterWorld (pos5);
		Vector3Int cello3 = tilemap.WorldToCell (cellcenterpos3);

		Debug.Log(" scan found "+other.name);
		if (other.name == "delayedcollider") 
		{
			//run
			Debug.Log("scan is working btch");
			bombisfound = true;
			FindObjectOfType<bot> ().bomboisfoundo (cellcenterpos3);

		}

		else
		{
			FindObjectOfType<bot> ().bomboisnotfoundo ();
		}
		Debug.Log (" scan "+other.tag+" name "+other.name+" pos "+cello3);
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
