using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class brickcollider : MonoBehaviour 
{
	public Tilemap tilemap;
	public Tile destructilbeTile;
	void OnTriggerEnter2D(Collider2D Exploision)
	{
		Vector3 pos = gameObject.transform.position;
		Vector3Int cello = tilemap.WorldToCell (pos);
		Vector3 cellcenterpos = tilemap.GetCellCenterWorld (cello);
		cellcenterpos.z = 0f;
		Tile tile = tilemap.GetTile<Tile> (cello);
		//Debug.Log ("dth"+Exploision.tag+"name"+Exploision.name);
		if (Exploision.gameObject.name == "Exploision(Clone)") 
		{
			if (name == destructilbeTile.name) 
			{
				//trigger brick destruction 
				tilemap.SetTile (cello,null);
			
			}


		}
		//Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
