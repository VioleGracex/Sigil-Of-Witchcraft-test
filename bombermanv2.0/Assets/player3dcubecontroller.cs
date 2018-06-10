using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player3dcubecontroller : MonoBehaviour {
    NavMeshAgent agent1;
    // Use this for initialization
    //Animator anim;
    /* public float panSpeed = 2f;
     float lastpressed = 0;
     public float stealthduration = 3f;

     public void Doublethespeed()
     {
         panSpeed = 4;
     }
     public void powerupdurationend()
     {
         panSpeed = 2;
     }
     public void Stealthchar()
     {
         anim.SetBool("isstealth", true);
         stealthduration = 3f;
     }*/

    void Start ()
    {
        agent1 = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
     
       

      /*  if (anim.GetBool("isstealth") == true)
        {
            stealthduration -= Time.deltaTime;
        }
        if (stealthduration <= 0f)
        {
            anim.SetBool("isstealth", false);
        }*/
        if (Input.GetKey("w"))
        {
            Debug.Log("5RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            //anim.SetBool("iswalking", true);
            pos.z = pos.z + 1;
            agent1.SetDestination(pos);
           // anim.SetFloat("input_y", 1);
          //  anim.SetFloat("input_x", 0);
           // lastpressed = 0;
        }
        else if (Input.GetKey("s"))
        {
           // anim.SetBool("iswalking", true);
            pos.z = pos.z - 1;
            agent1.SetDestination(pos);
           // anim.SetFloat("input_y", -1);
           // anim.SetFloat("input_x", 0);
            //lastpressed = 1;
        }
        else if (Input.GetKey("d"))
        {
           // anim.SetBool("iswalking", true);
            pos.x = pos.x +1;
            agent1.SetDestination(pos);
           // anim.SetFloat("input_x", 1);
          //  anim.SetFloat("input_y", 0);
           // lastpressed = 2;
        }
        else if (Input.GetKey("a"))
        {
           // anim.SetBool("iswalking", true);
            pos.x = pos.x - 1;
            agent1.SetDestination(pos);
            //anim.SetFloat("input_x", -1);
            //anim.SetFloat("input_y", 0);
           // lastpressed = 3;
        }
       /* else
        {
            if (lastpressed == 0)
            {
                anim.SetFloat("input_y", 1);
                anim.SetFloat("input_x", 0);
            }
            else if (lastpressed == 1)
            {
                anim.SetFloat("input_y", -1);
                anim.SetFloat("input_x", 0);
            }
            else if (lastpressed == 2)
            {
                anim.SetFloat("input_y", 0);
                anim.SetFloat("input_x", 1);
            }
            else if (lastpressed == 3)
            {
                anim.SetFloat("input_y", 0);
                anim.SetFloat("input_x", -1);
            }
            anim.SetBool("iswalking", false);
        }*/

       // transform.position = pos;


    }

		
	
}
