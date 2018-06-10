using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2movement : MonoBehaviour
{


//	Rigidbody2D rbody;
	Animator anim;
	// Use this for initialization
	void Start()
	{
		//rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	public float panSpeed = 2f;
	float lastpressed = 0 ;
	public float stealthduration=3f;
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
		anim.SetBool ("isstealth", true);
		stealthduration=3f;
	}

	void Update () 
	{
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

		if (Input.GetKey ("o")) 
		{
			anim.SetBool("iswalking", true);
			pos.y += panSpeed * Time.deltaTime;
			movement_vector.y = panSpeed * Time.deltaTime;
			anim.SetFloat("input_y", 1);
			anim.SetFloat("input_x", 0);
			lastpressed = 0;
		}
		else if  (Input.GetKey ("l")) 
		{
			anim.SetBool("iswalking", true);
			pos.y -= panSpeed * Time.deltaTime;
			movement_vector.y = panSpeed * Time.deltaTime;
			anim.SetFloat("input_y", -1);
			anim.SetFloat("input_x", 0);
			lastpressed = 1;
		}
		else if  (Input.GetKey (";")) 
		{
			anim.SetBool("iswalking", true);
			pos.x += panSpeed * Time.deltaTime;
			movement_vector.x = panSpeed * Time.deltaTime;
			anim.SetFloat("input_x", 1);
			anim.SetFloat("input_y", 0);
			lastpressed = 2;
		}
		else if  (Input.GetKey ("k"))
		{
			anim.SetBool("iswalking", true);
			pos.x -= panSpeed * Time.deltaTime;
			movement_vector.x = panSpeed * Time.deltaTime;
			anim.SetFloat("input_x", -1);
			anim.SetFloat("input_y", 0);
			lastpressed = 3;
		} 
		else 
		{
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

	}

}