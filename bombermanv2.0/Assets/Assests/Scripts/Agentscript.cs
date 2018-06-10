using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agentscript : MonoBehaviour {

    private NavMeshAgent agent;
    public GameObject player1;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = (player1.transform.position);
        agent.SetDestination(pos);
		

	}
}
