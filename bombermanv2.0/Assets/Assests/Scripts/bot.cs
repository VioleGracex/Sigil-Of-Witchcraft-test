using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bot : MonoBehaviour
{


	//	Rigidbody2D rbody;
	Animator anim;
	// Use this for initialization
	void Start()
	{
		//rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	public float panSpeed = 1.5f;
	float lastpressed = 0 ;
	public float stealthduration=3f;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public Tilemap tilemap;
	public Tile walltile;
	public Tile destructilbeTile;
	public Tile grass;
	public Tile outside;
	char cellup1='w';
	char cellup2='w';
	char cellupright='w';
	char cellupleft='w';
	char celldown1='w';
	char celldown2='w';
	char celldownright='w';
	char celldownleft='w';
	char cellright1='w';
	char cellright2='w';
	char cellrightup='w';
	char cellrightdown='w';
	char cellleft1='w';
	char cellleft2='w';
	char cellleftup='w';
	char cellleftdown='w';
	//bool movedtobrickpos=false;
	char keydownup='i';
	char keydowndown='i';
	char keydownright='i';
	char keydownleft='i';
	Vector3 save1;
	Vector3 destination;
	Vector3Int destination2;
	int onetimesave=1;
	char cellstate='e';
	Vector3Int nearestrunepos;
	bool bombisfound=false;
	Vector3 pos6;
	Vector3Int pos5;
	Vector3Int pos4;
	Vector3Int pos0;
	Vector3Int cello4;
	Vector3Int cello2;
	Vector3Int cello5;
	Vector3 cellcenterpos3;
	Vector3 cellcenterpos2;
	Vector3 cello3;
	bool adjustx=true;
	bool adjusty=false;
	public float bombexploded=2f;
	//bool runtoplayer = true;
	public float countdown = 1.5f;
	public float countdown2 = 1.5f;
	public float countdown3 = 0.8f;
	bool isidle=true;
	public TilemapCollider2D map1collider;
	public int targetplayer=1;
	Vector3 cellcenterpos4;
	Vector3 cellcenterpos5;
	Vector3Int save10;
	public float countdown4=0.5f;
	bool wallisblocking=false;
	Vector3 node1;
	Vector3 node2;
	Vector3 node3;
	Vector3 node4;
	Vector3 node5;
	Vector3 node6;
	//int botorder=0;
	//bool freecell=false;

	public void Doublethespeed()
	{
		panSpeed = 3f;
	}
	public void powerupdurationend()
	{
		panSpeed = 1.5f;
	}

	public void Stealthchar()
	{
		anim.SetBool ("isstealth", true);
		stealthduration=3f;
	}
	public void botorders (int order,Vector3Int cellback)
	{
		
		
	}
	public char botscan(Vector3Int cell)
	{
		
		Tile tile = tilemap.GetTile<Tile> (cell);

		if (tile == destructilbeTile) {
			
			cellstate = 'b';
		} else if (tile == walltile) {
			
			cellstate = 'w';
		} else if (tile == outside) 
		{
			cellstate = 's';
		}
		else  
		{
			
			cellstate = 'g';
		}
		return cellstate;
	}
	public void positionsaver(Vector3 save)
	{
		
	}
	public void reachedDestinationx ()
	{
		 keydownright='i';
		 keydownleft='i';
	}
	public void reachedDestinationy ()
	{
		keydownup='i';
		keydowndown='i';

	}
	public void foundobricko(Vector3 cell)
	{
		cello3 = cell;
	}
	public void bomboisfoundo(Vector3 cell)
	{
		bombisfound = true;
		cello3 = cell;
	}
	public void bomboisnotfoundo()
	{
		bombisfound = false;

	}
	public void setbombexplodedtime()
	{
		bombexploded = 3f;
	}
	public void resetonetime()
	{
		onetimesave = 1;
	}
	public void player1foundo()
	{
		targetplayer = 1;
	}

	public void player3foundo()
	{
		targetplayer = 2;
	}
	public void player4foundo()
	{
		targetplayer = 3;
	}



	void Update ()
	{
		//if (player1.activeSelf == true||player3.activeSelf) 
		//{
		if (panSpeed == 3f)
		{
			bombexploded = 4f;
		}
		if (countdown > 0) {
			countdown -= Time.deltaTime;
		}
		if (countdown2 > 0) {
			countdown2 -= Time.deltaTime;
		}
		if (countdown3 > 0) {
			countdown3 -= Time.deltaTime;
		}
		if (bombexploded > 0) {
			bombexploded -= Time.deltaTime;
		}
		if (countdown4 > 0) 
		{
			countdown4 -= Time.deltaTime;
		}

		Vector3 pos1 = new Vector3 (player1.transform.position.x, player1.transform.position.y, player1.transform.position.z);  
		Vector3 pos2 = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);  
		Vector3 pos8 = new Vector3 (player3.transform.position.x, player3.transform.position.y, player3.transform.position.z); 
		Vector3 pos9 = new Vector3 (player4.transform.position.x, player4.transform.position.y, player4.transform.position.z);  
		Vector3Int pos3 = tilemap.WorldToCell (pos2);
		Vector3 cellcenterpos = tilemap.GetCellCenterWorld (pos3);
		Vector3Int cello = tilemap.WorldToCell (cellcenterpos); //player2 world pos
		Debug.Log("cellcenter"+cellcenterpos);
		Vector3Int pos4 = tilemap.WorldToCell (pos1);
		Vector3 cellcenterpos2 = tilemap.GetCellCenterWorld (pos4);
		Vector3Int cello2 = tilemap.WorldToCell (cellcenterpos2); //player1 world pos 
		Vector3 node1 =  (cellcenterpos)+new Vector3 (2f,0,0);
		node1.y = cellcenterpos2.y;
		Vector3 node2 =  (cellcenterpos)+new Vector3 (-2f,0,0);
		node2.y = cellcenterpos2.y;
		Vector3 node3 =  (cellcenterpos)+new Vector3 (0,2f,0);
		node3.x = cellcenterpos2.x;
		Vector3 node4 =  (cellcenterpos)+new Vector3 (0,-2f,0);
		node4.x = cellcenterpos2.x;

		Vector3Int pos0 = tilemap.WorldToCell (pos8);
		Vector3 cellcenterpos4 = tilemap.GetCellCenterWorld (pos0);
		Vector3Int cello4 = tilemap.WorldToCell (cellcenterpos4); //player1 world pos }

		Vector3Int pos5 = tilemap.WorldToCell (pos9);
		Vector3 cellcenterpos5 = tilemap.GetCellCenterWorld (pos5);
		Vector3Int cello5 = tilemap.WorldToCell (cellcenterpos5); //player1 world pos }


		if (onetimesave == 1)
		{
			if (player1.activeSelf && player3.activeSelf && player4.activeSelf)
			{
				targetplayer = Random.Range (1, 4);
			} else if (player3.activeSelf && player4.activeSelf) 
			{
				targetplayer = Random.Range (2, 4);
			} else if (player1.activeSelf && player4.activeSelf)
			{
				targetplayer = Random.Range (5, 7);
				if (targetplayer == 5) {
					targetplayer = 1;
				} else {
					targetplayer = 3;
				}
			} else if (player1.activeSelf && player3.activeSelf) 
			{
				targetplayer = Random.Range (1, 3);
			} 
			else 
			{
				targetplayer = 1;
			}
		

		save1 = pos2;
		//Debug.Log ("cellcenter" + cello);
		cellright1 = botscan (cello + new Vector3Int (1, 0, 0));
		cellright2 = botscan (cello + new Vector3Int (2, 0, 0));
		cellrightup = botscan (cello + new Vector3Int (1, 1, 0));
		cellrightdown = botscan (cello + new Vector3Int (1, -1, 0));

		cellleft1 = botscan (cello + new Vector3Int (-1, 0, 0));
		cellleft2 = botscan (cello + new Vector3Int (-2, 0, 0));
		cellleftup = botscan (cello + new Vector3Int (1, 1, 0));
		cellleftdown = botscan (cello + new Vector3Int (1, -1, 0));

		cellup1 = botscan (cello + new Vector3Int (0, 1, 0));
		cellup2 = botscan (cello + new Vector3Int (0, 2, 0));
		cellupright = cellrightup;
		cellupleft = cellleftup;

		celldown1 = botscan (cello + new Vector3Int (0, -1, 0));
		celldown2 = botscan (cello + new Vector3Int (0, -2, 0));
		celldownright = botscan (cello + new Vector3Int (1, -1, 0));
		celldownleft = botscan (cello + new Vector3Int (-1, -1, 0));

		/*Debug.Log (" up1,2  " + cellup1 + "  cell2  " + cellup2);
			Debug.Log (" down1,2  "  + celldown1 + "cell2  " + celldown2+"    downright   "+celldownright+" downleft  "+celldownleft);
			Debug.Log (" right1,2  " + cellright1 + "cell2  " + cellright2+"   rightup  "+cellrightup+" rightdown  "+cellrightdown);
			Debug.Log (" left1,2  " + cellleft1 + "cell2  " + cellleft2+"    leftup  "+cellleftup+" leftdown  "+cellleftdown);*/
		onetimesave = 0;
	}

			
			if (save1 != pos2) 
			{
				cellright1=botscan (cello + new Vector3Int (1, 0, 0));
				cellright2=botscan (cello + new Vector3Int (2, 0, 0));
				cellrightup=botscan (cello + new Vector3Int (1, 1, 0));
				cellrightdown=botscan (cello + new Vector3Int (1, -1, 0));

				cellleft1=botscan (cello + new Vector3Int (-1, 0, 0));
				cellleft2=botscan (cello + new Vector3Int (-2, 0, 0));
				cellleftup=botscan (cello + new Vector3Int (1, 1, 0));
				cellleftdown=botscan (cello + new Vector3Int (1, -1, 0));

				cellup1=botscan (cello + new Vector3Int (0, 1 , 0));
				cellup2=botscan (cello + new Vector3Int (0, 2 , 0));
				cellupright=cellrightup;
				cellupleft=cellleftup;

				celldown1=botscan (cello + new Vector3Int (0, -1, 0));
				celldown2=botscan (cello + new Vector3Int (0, -2, 0));
				celldownright=botscan (cello + new Vector3Int (1, -1, 0));
				celldownleft=botscan (cello + new Vector3Int (-1, -1, 0));


			Debug.Log (" up1,2  " + cellup1 + "  cell2  " + cellup2);
			Debug.Log (" down1,2  "  + celldown1 + "cell2  " + celldown2+"    downright   "+celldownright+" downleft  "+celldownleft);
			Debug.Log (" right1,2  " + cellright1 + "cell2  " + cellright2+"   rightup  "+cellrightup+" rightdown  "+cellrightdown);
			Debug.Log (" left1,2  " + cellleft1 + "cell2  " + cellleft2+"    leftup  "+cellleftup+" leftdown  "+cellleftdown);
				save1 = pos2;

			}
			Debug.Log ("isidle" + isidle);
		if (isidle == true&&bombexploded<=0) 
			{
				if(targetplayer == 1)
				{
					destination = cellcenterpos2;
				}
			    if(targetplayer == 2)
				{
					destination = cello4;
				}
				 if(targetplayer == 3)
				{
					destination = cello5;
				}
				if(targetplayer == 4)
				{
					destination = node1;
				}
				if(targetplayer == 5)
				{
					destination = node2;
				}
				if(targetplayer == 6)
				{
					destination = node3;
				}
				if(targetplayer == 7)
				{
					destination = node4;
				}
				

				
		
				



			}
	
		Debug.Log ("iswallblocking" + wallisblocking);
		if (keydownup == 'o' && cellup1 == 'w' ) 
		{
			//adjustx = true;
			//adjusty = false;
			wallisblocking = true;
			/*if (cellup2 == 's')
			{
				keydownup = 'i';
			}*/
			countdown3 = 0.8f;
			if (cellleft1 == 'w' && cellright1 == 'g' && cellupright == 'w'&&cellup2 != 's'&&bombisfound==false   || cellupright == 'b'&&cellup2 != 's' &&bombisfound==false   || cellleft1 == 'g' && cellright1 == 'g' && cellupright == 'w'&&cellup2 != 's'&&bombisfound==false   ) 
			{
				Debug.Log ("tryfix132342"+node1);
				targetplayer = 5;
				adjustx = true;
				adjusty = false;
			}
			if (cellright1 == 'w' && cellleft1 == 'g' && cellupleft == 'w' &&cellup2 != 's' &&bombisfound==false  || cellupleft == 'b' &&cellup2 != 's'&&bombisfound==false   || cellright1 == 'g' && cellleft1 == 'g' && cellupleft == 'w'&&cellup2 != 's' &&bombisfound==false  ) 
			{
				wallisblocking = true;
				Debug.Log ("tryfix12");
				targetplayer = 4;
				adjustx = true;
				adjusty = false;

			}else 
			{
				wallisblocking = false;
			}
		} else if (keydownleft == 'k' && cellleft1 == 'w' ) 
		{	
			//adjustx = false;
			//adjusty = true;
			wallisblocking = true;
			/*if (cellleft2 == 's')
			{
				keydownleft = 'i';
			}*/
			countdown3 = 0.8f;

			if (celldown1 == 'w' && cellup1 == 'g' && cellleftup == 'w' &&cellleft2 != 's' &&bombisfound==false || cellleftup == 'b' &&cellleft2 != 's'&&bombisfound==false  || cellup1 == 'g' && celldown1 == 'g' && cellleftup == 'w'&&cellleft2 != 's'&&bombisfound==false  ) 
			{
				wallisblocking = true;
				targetplayer = 6;
				adjustx = false;
				adjusty = true;
			}
			if (cellup1 == 'w' && celldown1 == 'g' && cellleftdown == 'w'&&cellleft2 != 's' &&bombisfound==false  || cellleftdown == 'b'&&cellleft2 != 's'&&bombisfound==false   || celldown1 == 'g' && cellup1 == 'g' && cellleftdown == 'w'&&cellleft2 != 's'&&bombisfound==false ||cellleft1=='g'&&celldownleft=='g'&&celldownright=='w'&&bombisfound==false&&cellleft2!='s' ) 
			{
				wallisblocking = true;
				targetplayer = 7;
				adjustx = false;
				adjusty = true;
			}else 
			{
				wallisblocking = false;
			}

		} else if (keydownright == ';' && cellright1 == 'w') 
		{
			//adjustx = false;
			//adjusty = true;

			/*if (cellright2 == 's')
			{
				keydownright = 'i';
			}*/
			countdown3 = 0.8f;
			if (celldown1 == 'w' && cellup1 == 'g' && cellrightup == 'w'&&cellright2 != 's'&&bombisfound==false   || cellrightup == 'b'&&cellright2 != 's'&&bombisfound==false    || cellup1 == 'g' && celldown1 == 'g' && cellrightup == 'w'&&cellright2 != 's' &&bombisfound==false  ) 
			{
				wallisblocking = true;
				targetplayer = 7;
				adjustx = false;
				adjusty = true;
			}
			 if (cellup1 == 'w' && celldown1 == 'g' && cellrightdown == 'w' &&cellright2 != 's' &&bombisfound==false  || cellrightdown == 'b'&&cellright2 != 's'&&bombisfound==false    || celldown1 == 'g' && cellup1 == 'g' && cellrightdown == 'w'&&cellright2 != 's'&&bombisfound==false   ) 
			{
				wallisblocking = true;
				targetplayer = 6;
				adjustx = false;
				adjusty = true;

			}else 
			{
				wallisblocking = false;
			}

		} else if (keydowndown == 'l' && celldown1 == 'w' )
		{
			//adjustx = true;
			//adjusty = false;
			wallisblocking = true;
			Debug.Log ("tryfix11111");
			/*if (celldown2 == 's') 
			{
				keydowndown = 'i';
			}*/
			countdown3 = 0.8f;
			if (cellleft1 == 'w' && cellright1 == 'g' && celldownright == 'w'&&celldown2 != 's'&&bombisfound==false  ||cellleft1 == 'w' && cellright1 == 'g' && celldownright == 'g'&&celldown2 != 's'&&bombisfound==false  ||celldownright == 'b'&&celldown2 != 's' &&bombisfound==false  || cellleft1 == 'g' && cellright1 == 'g' && celldownright == 'w'&&celldown2 != 's' &&bombisfound==false ) 
			{
				
				Debug.Log ("tryfix132342"+node1);
				wallisblocking = true;
				targetplayer = 4;
				adjustx = true;
				adjusty = false;

			}
			if (cellright1 == 'w' && cellleft1 == 'g' && celldownleft == 'w' && celldown2 != 's' && bombisfound == false || celldown2=='w'&&celldownleft=='g'&&cellright1=='b'|| celldownleft == 'b' && celldown2 != 's' && bombisfound == false || cellright1 == 'g' && cellleft1 == 'g' && celldownleft == 'w' && celldown2 != 's' && bombisfound == false) {
				wallisblocking = true;
				Debug.Log ("tryfix1");
				targetplayer = 5;
				adjustx = true;
				adjusty = false;

			} else 
			{
				wallisblocking = false;
			}

		} 
		else
		{ 
			if (wallisblocking == false) 
			{
				targetplayer = 1;
			}

			//adjustx = true;
			//adjusty = false;
		} 

		if (countdown4 <= 0) 
		{
			save10.x =Mathf.FloorToInt(cellcenterpos.x);
			save10.y = Mathf.FloorToInt(cellcenterpos.y);
			Debug.Log ("save10x" + save10.x);
		}

			if (bombisfound == true) 
			{
			
				//runtoplayer = false;
				if (cello3 == cellcenterpos) 
				{
					if (cellright1 == 'g' && cellright2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownright = ';';

						destination = (cellcenterpos) + (new Vector3Int (2, 0, 0));

					}
					else if (cellleft1 == 'g' && cellleft2 == 'g') {
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownleft = 'k';
						destination = (cellcenterpos) + (new Vector3Int (-2, 0, 0));
					} 
					else if (cellup1 == 'g' && cellup2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (o,o)
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (0, 2, 0));
					} 
					else if (celldown1 == 'g' && celldown2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (0, -2, 0));
					} 
					else if (cellup1 == 'g' && cellupright == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					}
					else if (cellup1 == 'g' && cellupleft == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x)
						{
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownright == 'g') 
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) {
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownleft == 'g')
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (-1, -1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) {
							keydownleft = 'k';
						}
					}
					else if (cellright1 == 'g' && cellrightup == 'g') 
					{
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) {
							keydownleft = 'k';
						}
						keydownup = 'o';
					}
					else if (cellright1 == 'g' && cellrightdown == 'g')
					{
						destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) {
							keydownleft = 'k';
						}
						keydownup = 'o';
					}
					else if (cellleft1 == 'g' && cellleftup == 'g') 
					{
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
						keydowndown = 'l';
					} 

				}
			else if (cello3 == (cellcenterpos) + new Vector3Int (1, 0, 0))
				{
					if (cellleft1 == 'g' && cellleft2 == 'g')
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownleft = 'k';
						destination = (cellcenterpos) + (new Vector3Int (-2, 0, 0));
					} 
					else if (cellup1 == 'g' && cellup2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (o,o)
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (0, 2, 0));
					} 
					else if (celldown1 == 'g' && celldown2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (0, -2, 0));
					} 
					else if (cellup1 == 'g' && cellupright == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					}
					else if (cellup1 == 'g' && cellupleft == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownright == 'g') 
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x)
						{
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownleft == 'g')
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (-1, -1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					}

				}
			Debug.Log ("cellomid3"+cellcenterpos);
				//checkpoint5
		  if (cello3 == (cellcenterpos) + new Vector3Int (-1, 0, 0)) 
				{
					Debug.Log ("thisRAN");
					if (cellright1 == 'g' && cellright2 == 'g')
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownright = ';';
						destination = (cellcenterpos) + (new Vector3Int (2, 0, 0));

					} 
					else if (cellup1 == 'g' && cellup2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (o,o)
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (0, 2, 0));
					} 
					else if (celldown1 == 'g' && celldown2 == 'g')
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (0, -2, 0));
					} 
					else if (cellup1 == 'g' && cellupright == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x)
						{
							keydownleft = 'k';
						}
					} 
					else if (cellup1 == 'g' && cellupleft == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x)
						{
							keydownleft = 'k';
						}
					} else if (celldown1 == 'g' && celldownright == 'g') 
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownleft == 'g')
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (-1, -1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					}

				}

				Debug.Log (" pos " + cellcenterpos + "dest :" + destination);
			 if (cello3 == (cellcenterpos) + new Vector3Int (0, 1, 0))
				{
					if (cellright1 == 'g' && cellright2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownright = ';';
						destination = (cellcenterpos) + (new Vector3Int (2, 0, 0));

					} 
					else if (cellleft1 == 'g' && cellleft2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownleft = 'k';
						destination = (cellcenterpos) + (new Vector3Int (-2, 0, 0));
					}
					else if (celldown1 == 'g' && celldown2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (0, -2, 0));
					} 
					else if (celldown1 == 'g' && celldownright == 'g') 
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x)
						{
							keydownleft = 'k';
						}
					} 
					else if (celldown1 == 'g' && celldownleft == 'g') 
					{
						keydowndown = 'l';
						destination = (cellcenterpos) + (new Vector3Int (-1, -1, 0));
						if (destination.x < cellcenterpos.x)
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					} 
					else if (cellleft1 == 'g' && cellleftup == 'g') 
					{
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
						keydowndown = 'l';
					} 
					else if (cellright1 == 'g' && cellrightup == 'g') 
					{
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} 
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
						keydownup = 'o';
					}

				}

				else if (cello3 == (cellcenterpos) + new Vector3Int (0, -1, 0)) 
				{
					if (cellup1 == 'g' && cellup2 == 'g')
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (o,o)
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (0, 2, 0));
					}
					else if (cellright1 == 'g' && cellright2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownright = ';';
						destination = (cellcenterpos) + (new Vector3Int (2, 0, 0));

					} 
					else if (cellleft1 == 'g' && cellleft2 == 'g') 
					{
						//place bomb and go to cellleft2
						//movement to cellleft2 (k,k)
						keydownleft = 'k';
						destination = (cellcenterpos) + (new Vector3Int (-2, 0, 0));
					} 
					else if (cellup1 == 'g' && cellupright == 'g') 
					{
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (1, 1, 0));
						if (destination.x < cellcenterpos.x) {
							keydownright = ';';
						} else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						}
					} 
					else if (cellup1 == 'g' && cellupleft == 'g') 
					{
						//checkpoint1
						keydownup = 'o';
						destination = (cellcenterpos) + (new Vector3Int (-1, 1, 0));
						if (destination.x < cellcenterpos.x) 
						{
							keydownright = ';';
						}
						else if (destination.x > cellcenterpos.x) 
						{
							keydownleft = 'k';
						} 
						else if (cellleft1 == 'g' && cellleftdown == 'g')
						{
							destination = (cellcenterpos) + (new Vector3Int (-1, -1, 0));
							if (destination.x < cellcenterpos.x)
							{
								keydownright = ';';
							} 
							else if (destination.x > cellcenterpos.x)
							{
								keydownleft = 'k';
							}
							keydowndown = 'l';

						} 
						else if (cellright1 == 'g' && cellrightdown == 'g')
						{
							destination = (cellcenterpos) + (new Vector3Int (1, -1, 0));
							if (destination.x < cellcenterpos.x) {
								keydownright = ';';
							} else if (destination.x > cellcenterpos.x) {
								keydownleft = 'k';
							}
							keydownup = 'o';

						}
					}

				}
			}
		Debug.Log ("adjustx" + adjustx);
		Debug.Log ("adjusty" + adjusty);
			//checkpoint4
		Debug.Log(" target "+targetplayer +"pos"+cellcenterpos+ "dest to target " +destination);
		//if (wallisblocking == false) 
		//{
			if (targetplayer == 1) 
			{ 
			Debug.Log ("TRUEEEEEE");
				if (bombisfound == false && player1.activeSelf && bombexploded <= 0) 
			{
				Debug.Log ("TRUEEEEEE1");
					/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

					if (adjustx == true) 
				{
						Debug.Log ("TRUEEEEEE2");
						if (cellcenterpos.x != cellcenterpos2.x) 
					{	Debug.Log ("TRUEEEEEE3");
						if (cellcenterpos.x < cellcenterpos2.x) 
						{
							keydownright = ';';
						} 
						else if (cellcenterpos.x > cellcenterpos2.x) 
						{
							keydownleft = 'k';
						} 
						else
						{
							adjustx = false;
							adjusty = true;
						}
					}
				}
				else if   (adjusty == true) 
				{
						if (cellcenterpos.y != cellcenterpos2.y) 
					{
							if (cellcenterpos.y < cellcenterpos2.y) 
						{
								keydownup = 'o';
						} 
						else if (cellcenterpos.y > cellcenterpos2.y) 
						{
								keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
					}
				}
			}
			}
			if (targetplayer == 2) {
				if (bombisfound == false && player3.activeSelf && bombexploded <= 0) {
					/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

					if (adjustx == true) 
				{
						if (cellcenterpos.x != cello4.x) {
							if (cellcenterpos.x < cello4.x) {
								keydownright = ';';
						} else if (cellcenterpos.x > cello4.x) {
								keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
						}
					}
					else if (adjusty == true) {
					if (cellcenterpos.y != cello4.y) {
						if (cellcenterpos.y < cello4.y) {
								keydownup = 'o';
						} else if (cellcenterpos.y > cello4.y) {
								keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
						}
					}
				}
			}
			if (targetplayer == 3) {
				if (bombisfound == false && player4.activeSelf && bombexploded <= 0) {
					/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

					if (adjustx == true) {
						if (cellcenterpos.x != cello5.x) {
							if (cellcenterpos.x < cello5.x) {
								keydownright = ';';
							} else if (cellcenterpos.x > cello5.x) {
								keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
						}
					}
					else if (adjusty == true) {
						if (cellcenterpos.y != cello5.y) {
							if (cellcenterpos.y < cello5.y) {
								keydownup = 'o';
							} else if (cellcenterpos.y > cello5.y) {
								keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
						}
					}
				}
			}
		if (targetplayer == 4) {
			if (bombisfound == false && player1.activeSelf && bombexploded <= 0) {
				/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

				if (adjustx == true) {
					if (cellcenterpos.x != node1.x) {
						if (cellcenterpos.x < node1.x) {
							keydownright = ';';
						} else if (cellcenterpos.x > node1.x) {
							keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
					}
				}
				else if (adjusty == true) {
					if (cellcenterpos.y != node1.y) {
						if (cellcenterpos.y < node1.y) {
							keydownup = 'o';
						} else if (cellcenterpos.y > node1.y) {
							keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
					}
				}
			}
		}
		if (targetplayer == 5) {
			if (bombisfound == false && player1.activeSelf && bombexploded <= 0) {
				/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

				if (adjustx == true) {
					if (cellcenterpos.x != node2.x) {
						if (cellcenterpos.x < node2.x) {
							keydownright = ';';
						} else if (cellcenterpos.x > node2.x) {
							keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
					}
				}
				else if (adjusty == true) {
					if (cellcenterpos.y != node2.y) {
						if (cellcenterpos.y < node2.y) {
							keydownup = 'o';
						} else if (cellcenterpos.y > node2.y) {
							keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
					}
				}
			}
		}
		if (targetplayer == 6) {
			if (bombisfound == false && player1.activeSelf && bombexploded <= 0) {
				/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

				if (adjustx == true) {
					if (cellcenterpos.x != node3.x) {
						if (cellcenterpos.x < node3.x) {
							keydownright = ';';
						} else if (cellcenterpos.x > node3.x) {
							keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
					}
				}
				else if (adjusty == true) {
					if (cellcenterpos.y != node3.y) {
						if (cellcenterpos.y < node3.y) {
							keydownup = 'o';
						} else if (cellcenterpos.y > node3.y) {
							keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
					}
				}
			}
		}
		if (targetplayer == 7) {
			if (bombisfound == false && player1.activeSelf && bombexploded <= 0) {
				/*if (gameObject.transform.position != player1.transform.position)
				{
					keydownleft = 'k';

				}*/

				if (adjustx == true) {
					if (cellcenterpos.x != node4.x) {
						if (cellcenterpos.x < node4.x) {
							keydownright = ';';
						} else if (cellcenterpos.x > node4.x) {
							keydownleft = 'k';
						}else
						{
							adjustx = false;
							adjusty = true;
						}
					}
				}
				else if (adjusty == true) {
					if (cellcenterpos.y != node4.y) {
						if (cellcenterpos.y < node4.y) {
							keydownup = 'o';
						} else if (cellcenterpos.y > node4.y) {
							keydowndown = 'l';
						}else
						{
							adjustx = true;
							adjusty = false;
						}
					}
				}
			}
		}
		//}
				//checkpoint2
				if(bombisfound==true)
				{
					if ( countdown <=0f && cellcenterpos.x != destination.x ) 
					{
						reachedDestinationx ();
						countdown = 1.5f;
					}
					if (countdown <= 0f && cellcenterpos.y != destination.y) 
					{
						reachedDestinationy ();
					}
					if (keydownleft == 'i' && keydownright == 'i' && keydownup == 'i' && keydowndown == 'i') 
					{
						countdown = 1.5f;
						bombexploded = 3f;
					}
				}



				Debug.Log ("isbombfound" + bombisfound);


				//destination = (destination) + new Vector3 (0.1f, 0.01f, 0);

				if (destination.x == cellcenterpos.x) 
				{
					Debug.Log ("true");
					reachedDestinationx ();
					adjustx = false;
					adjusty = true;
					//movedtobrickpos = true;

				}

				 if (destination.y == cellcenterpos.y) 
				{
					reachedDestinationy ();
					adjustx = true;
					adjusty = false;
					//movedtobrickpos = true;
				} 
				else
				{

				}
				if (destination.x == cellcenterpos.x && destination.y == cellcenterpos.y)
				{
					//runtoplayer = true;
					bombisfound = false;
				}
		if (Mathf.FloorToInt(save10.x) == Mathf.FloorToInt(cellcenterpos.x)&&countdown4<=0) 
		{
			//keydownright=';';
			countdown4 = 3f;
		}
		if (Mathf.FloorToInt(save10.y) == Mathf.FloorToInt(cellcenterpos.y)&&countdown4<=0)
		{
			countdown4 = 3f;

		}
		//checkpoint9
		if ( countdown2 <=0f ) 
			{
				bombisfound = false;
				reachedDestinationx ();
			//adjustx = true;
			//adjusty = false;

				if (cellright1 == 'b' || cellleft1 == 'b') 
				{	
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}

			}
		if (countdown2 <= 0f ) 
			{
				bombisfound = false;
				reachedDestinationy ();
				//adjustx = true;
				//adjusty = false;

				if (cellup1 == 'b' || celldown1 == 'b') 
				{	
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}
			}
			if (keydownleft == 'i' && keydownright == 'i' && keydownup == 'i' && keydowndown == 'i') 
			{
				countdown2 = 1.5f;
				bombisfound = false;
			}
			//checkpoint3
			if (bombisfound==false)
			{


			/*if ( countdown <=0f && cello.x != destination2.x ) 
				{
					bombisfound = false;
					reachedDestinationx ();
					if (cellright1 == 'b' || cellleft1 == 'b') 
					{
						FindObjectOfType<bombspawner2> ().activedabomb ();
						bombexploded = 3f;
					}
				}
				if (countdown <= 0f && cello.y != destination2.y) 
				{
					bombisfound = false;
					reachedDestinationy ();
					if (cellup1 == 'b' || celldown1 == 'b') 
					{	
						FindObjectOfType<bombspawner2> ().activedabomb ();	
						bombexploded = 3f;
					}

				}*/
				if (keydownleft == 'i' && keydownright == 'i' && keydownup == 'i' && keydowndown == 'i') 
				{
					countdown = 1.5f;
					bombisfound = false;
				}
				if (cellcenterpos == cellcenterpos2 + new Vector3 (0.5f, 0, 0)) 
				{
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}
			if (cellcenterpos == cellcenterpos2 + new Vector3 (-0.5f, 0, 0)) 
				{
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}
				if (cellcenterpos == cellcenterpos2+ new Vector3 (0, -0.5f, 0)) 
				{
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}
				if (cellcenterpos == cellcenterpos2 + new Vector3 (0, 0.5f, 0)) 
				{
					FindObjectOfType<bombspawner2> ().activedabomb ();
					bombexploded = 3f;
				}
			//checkpoint7
			if (cellcenterpos == cello4 + new Vector3 (0.5f, 0, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello4 + new Vector3 (-0.5f, 0, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello4+ new Vector3 (0, -0.5f, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello4 + new Vector3 (0, 0.5f, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			//
			if (cellcenterpos == cello5 + new Vector3 (0.5f, 0, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello5 + new Vector3 (-0.5f, 0, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello5 + new Vector3 (0, -0.5f, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			if (cellcenterpos == cello5 + new Vector3 (0, 0.5f, 0)) 
			{
				FindObjectOfType<bombspawner2> ().activedabomb ();
				bombexploded = 3f;
			}
			}

			if (anim.GetBool("isstealth") == true) 
			{
				stealthduration -= Time.deltaTime;
			}
			if (stealthduration <= 0f) 
			{
				anim.SetBool("isstealth",false);
			}
			Vector2 pos = transform.position;
			Vector2 movement_vector = new Vector2 (0,0);

			
			if (keydownup=='o') 
			{
				anim.SetBool("iswalking", true);
				isidle = false;
				pos.y += panSpeed * Time.deltaTime;
				movement_vector.y = panSpeed * Time.deltaTime;
				anim.SetFloat("input_y", 1);
				anim.SetFloat("input_x", 0);
				lastpressed = 0;
			}
			else if  (keydowndown=='l') 
			{
				anim.SetBool("iswalking", true);
				isidle = false;
				pos.y -= panSpeed * Time.deltaTime;
				movement_vector.y = panSpeed * Time.deltaTime;
				anim.SetFloat("input_y", -1);
				anim.SetFloat("input_x", 0);
				lastpressed = 1;
			}
			else if  (keydownright==';') 
			{
				anim.SetBool("iswalking", true);
				isidle = false;
				pos.x += panSpeed * Time.deltaTime;
				movement_vector.x = panSpeed * Time.deltaTime;
				anim.SetFloat("input_x", 1);
				anim.SetFloat("input_y", 0);
				lastpressed = 2;
			}
			else if  (keydownleft=='k')
			{
				anim.SetBool("iswalking", true);
				isidle = false;
				pos.x -= panSpeed * Time.deltaTime;
				movement_vector.x = panSpeed * Time.deltaTime;
				anim.SetFloat("input_x", -1);
				anim.SetFloat("input_y", 0);
				lastpressed = 3;
			} 
			else 
			{
				isidle = true;
				if (lastpressed == 0) 
				{
					anim.SetFloat("input_y", 1);
					anim.SetFloat("input_x", 0);
				}
				else if(lastpressed==1)
				{
					anim.SetFloat("input_y", -1);
					anim.SetFloat("input_x", 0);
				}
				else if (lastpressed==2)
				{
					anim.SetFloat("input_y", 0);
					anim.SetFloat("input_x", 1);
				}
				else if(lastpressed==3)
				{
					anim.SetFloat("input_y", 0);
					anim.SetFloat("input_x", -1);
				}
				anim.SetBool("iswalking", false);
			}

			transform.position = pos;
			//}
			//Debug.Log (" pos  " + pos + " cello " + cello);

		//}

		/*else
		{
			//reachedDestinationx ();
			//reachedDestinationy ();
		}*/

	}


}