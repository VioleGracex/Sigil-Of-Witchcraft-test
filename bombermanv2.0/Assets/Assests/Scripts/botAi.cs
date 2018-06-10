using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class botAi : MonoBehaviour {


	Transform target;
    public GameObject player1;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		target = playermanager.instance.player.transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
     
        Vector3 pos = player1.transform.position;
        float distance = Vector3.Distance(pos,transform.position);
        agent.SetDestination(player1.transform.position);
	
	}
}
