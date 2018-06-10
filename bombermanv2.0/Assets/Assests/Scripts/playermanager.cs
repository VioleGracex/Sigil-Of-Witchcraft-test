using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{

	// Use this for initialization
	public GameObject player;
	#region Singleton
	public static playermanager instance;
	void Awake()
	{
		instance = this;
	}
	#endregion

}
