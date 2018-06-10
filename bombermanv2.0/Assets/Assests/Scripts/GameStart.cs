using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
public class GameStart : MonoBehaviour
{
	public Slider botsnum;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject Gamestart;
	public TextMeshProUGUI GamestartTimer;
	public Tilemap firstmap;
	public Button pausemenu1;
	public Button pausemenu2;
	public  float countdowntostart=3f;
	public  int onetimestart=1;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (pausemenu1.isActiveAndEnabled) 
		{
			
		} 
		else if (pausemenu2.isActiveAndEnabled) 
		{
			
		}
		else
		{
			countdowntostart -= Time.deltaTime;
		}
		if (countdowntostart <= 3f && countdowntostart >= 2f) 
		{
			GamestartTimer.text ="3";
		}
		if (countdowntostart <= 2f && countdowntostart >= 1f) 
		{
			GamestartTimer.text ="2";
		}
		if (countdowntostart <= 1f && countdowntostart >= 0f) 
		{
			GamestartTimer.text ="1";
		}
		if (countdowntostart <= 0f && countdowntostart >= -1f) 
		{
			GamestartTimer.text ="Start";
		}
		if (countdowntostart <= -1f && countdowntostart >= -2f) 
		{
			
			Gamestart.SetActive (false);

		}
		if (countdowntostart <= 0f && onetimestart==1)
		{
			player1.SetActive (true);
			if (botsnum.value == 1)
			{
				//trigger spawn animation
				onetimestart = 0;
				player2.SetActive (true);
			}
			if (botsnum.value == 2)
			{
				onetimestart = 0;
				player2.SetActive (true);
				player3.SetActive (true);
			}
			if (botsnum.value == 3)
			{
				onetimestart = 0;
				player2.SetActive (true);
				player3.SetActive (true);
				player4.SetActive (true);
			}
			
		}
	}
}
