using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class radar : MonoBehaviour {
	
	//Radar Variables
    public skull controller;
    private CircleCollider2D radius;

	// Use this for initialization
	void Start () 
    {
        radius = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(controller.onLight)
        {
            radius.radius = 1f;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            controller.isAlerted = true;          
            radius.radius = 3.5f;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            controller.isAlerted = false;
            radius.radius = 2.5f;
        }   
    }
}
