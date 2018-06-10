using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class bombspawner : MonoBehaviour {

	// Use this for initialization
	public Tilemap tilemap;
	public GameObject bombprefab;



	public int bombcount=1;
    public float cooldown=0f;
	public void bombplus()
	{
		bombcount = 2;
	}

	// Update is called once per frame
	void Update () 
	{
		
		if (cooldown != 0f) 
		{if (cooldown <= 0f) 
			{
				cooldown = 0f;
			} 
			else 
			{
				cooldown = cooldown - Time.deltaTime;
			}
			
			//Debug.Log("cooldown="+count);
		}
		if (Input.GetKeyDown(KeyCode.E)) 
		{
            Scene scene = SceneManager.GetActiveScene();
            if (bombcount == 0 && cooldown == 0 && gameObject.activeSelf && scene.name == "bombermanv2.1")
            {
                bombcount = 1;
            }

            if (bombcount == 1) 
			{   cooldown = 3f;
				Vector3 pos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);  
				//Vector3 worldPos =   Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3Int cell = tilemap.WorldToCell (pos);
				Vector3 cellcenterpos = tilemap.GetCellCenterWorld (cell);
				cellcenterpos.z = 0f;
				Instantiate (bombprefab, cellcenterpos, Quaternion.identity);
				bombcount--;

			}
			if (bombcount <= 2&& 1<bombcount) 
			{ 
				Vector3 pos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);  
				//Vector3 worldPos =   Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3Int cell = tilemap.WorldToCell (pos);
				Vector3 cellcenterpos = tilemap.GetCellCenterWorld (cell);
				cellcenterpos.z = 0f;
				Instantiate (bombprefab, cellcenterpos, Quaternion.identity);
				bombcount--;
			}
		}


	}
}
