using UnityEngine;
using System.Collections;

public class radar : MonoBehaviour {

    public GameObject skull;
    public skull controller;

    private CircleCollider2D radius;

	// Use this for initialization
	void Start () 
    {
        skull = GameObject.Find("Skull");
        controller = skull.GetComponent<skull>();

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
