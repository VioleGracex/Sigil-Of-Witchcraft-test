using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuButtons : MonoBehaviour 
{
	public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;
	public Slider botsnum;
	public void ResumeGame()
	{
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	public void PauseGame()
	{
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void Restartlvl()
	{
		//SceneManager.LoadScene ("loading");
		SceneManager.LoadScene ("bombermanv2.1");

	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene ("menu");
	}
	void update()
	{
		
		/*if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) 
			{
				PauseMenuUI.SetActive (false);
				ResumeGame ();
			}
			else
			{
				PauseMenuUI.SetActive (true);
				PauseGame();
			}
		}*/
		
	}
}
