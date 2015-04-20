using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class radar : MonoBehaviour {
	//Dictonary of all monster that use radar
	public Dictionary<string, monster> MonsterLibrary = new Dictionary<string, monster>();
	//Radar Variables
    public GameObject attachedMon;
	private monster monsterSet;
    public monster controller;

    private CircleCollider2D radius;

	// Use this for initialization
	void Start () 
    {
		//Init the monster types that use radar
		MonsterLibrary.Add ("Skull", (monster)skull);
		MonsterLibrary.Add ("Ghost", (monster)ghost);
		//Radar setting its variables for its attached objected
        attachedMon = GameObject.Find("Skull");
		monsterSet = (monster) MonsterLibrary ["Skull"];
        controller = attachedMon.GetComponent<monsterSet>();

        radius = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            controller.isAlerted = true;
            controller.player = col.gameObject;
            radius.radius = 3f;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            controller.isAlerted = false;
            controller.player = null;
            radius.radius = 2f;
        }   
    }
}
