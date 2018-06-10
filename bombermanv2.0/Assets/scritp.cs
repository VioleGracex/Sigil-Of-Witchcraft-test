using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scritp : MonoBehaviour {
    public GameObject cube;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 cubepos = cube.transform.position;
        transform.position = cubepos;
        
		
	}
}
