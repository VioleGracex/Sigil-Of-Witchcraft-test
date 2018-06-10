using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaySettings : MonoBehaviour 
{
	public Slider botsnum;
	public TextMeshProUGUI botnumbervalue;
	string Boto;
	public void botsnumber ()
	{
		
		Debug.Log ("Botsnum" + botsnum.value);
		Boto = botsnum.value.ToString ();

		botnumbervalue.text =Boto;
	}
	public void startgame()
	{
		Time.timeScale = 1f;
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene ("menu");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
