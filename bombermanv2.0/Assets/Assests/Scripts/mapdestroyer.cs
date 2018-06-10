using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class mapdestroyer : MonoBehaviour 
{
	public Tilemap tilemap;
	public Tile walltile;
	public Tile destructilbeTile;
	public Tile grass;
	public GameObject explosionprefab;
	public GameObject bomb;
	public GameObject player;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	//bool isplayer1alive=true;
	//bool isplayer2alive=true;
	public GameObject broomprefab;
	public GameObject barrierprefab;
	public GameObject stealthprefab;
	int RandomPowerup;

	void Update () 
	{
		//RandomPowerup = Random.Range (1, 8);
		//Debug.Log ("RPU" + RandomPowerup);




	}

	public void Explode (Vector2 worldPos)
	{
		Vector3 pos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);  
		//Vector3 worldPos =   Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3Int cello = tilemap.WorldToCell (pos);
		Vector3 cellcenterpos = tilemap.GetCellCenterWorld (cello);
		cellcenterpos.z = 0f;
//		Vector3 bombpos =new Vector3 (bomb.transform.position.x,bomb.transform.position.y,bomb.transform.position.z);
		Vector3Int originCell = tilemap.WorldToCell(worldPos) ;
		ExplodeCell (originCell);
		//Debug.Log ("cell" + originCell);
		if (ExplodeCell (originCell + new Vector3Int (1, 0, 0)))
		{
			//ExplodeCell (originCell+new Vector3Int(2,0,0));
		}


		if (ExplodeCell (originCell + new Vector3Int (0, 1, 0))) 
		{
			//ExplodeCell (originCell+new Vector3Int(0,2,0));
		}
	
		if(ExplodeCell (originCell+new Vector3Int(-1,0,0)))
		{
			//ExplodeCell (originCell+new Vector3Int(-2,0,0));
		}

		if (ExplodeCell (originCell + new Vector3Int (0, -1, 0))) 
		{
			//ExplodeCell (originCell+new Vector3Int(0,-2,0));
		}

	


	}

	bool ExplodeCell (Vector3Int cell)
	{ 

		RandomPowerup = Random.Range (1, 12);
		//Debug.Log ("RPU" + RandomPowerup);
		Tile tile = tilemap.GetTile<Tile> (cell);
		//Debug.Log ("title" + tile);
		if (tile == walltile) 
		{
			return false;
		} 
		if (tile == destructilbeTile) 
		{
			//trigger brick destruction 
			tilemap.SetTile (cell,null);
		}

		Vector3 posexplosion = tilemap.GetCellCenterWorld(cell);
		Instantiate (explosionprefab, posexplosion, Quaternion.identity);
		if (tile == destructilbeTile&&RandomPowerup==1) 
		{
			Instantiate (broomprefab,posexplosion, Quaternion.identity);

		}
		if (tile == destructilbeTile&&RandomPowerup==2) 
		{
			Instantiate (barrierprefab,posexplosion, Quaternion.identity);

		}
		if (tile == destructilbeTile&&RandomPowerup==3) 
		{
			Instantiate (stealthprefab,posexplosion, Quaternion.identity);

		}
		if (tile == destructilbeTile && RandomPowerup == 4) 
		{
			//Instantiate (Runeprefab, cell, Quaternion.identity);

		}
		else
		{
			
		}
		return true;
	}
}
