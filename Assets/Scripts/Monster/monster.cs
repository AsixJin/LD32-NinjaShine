using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {

    //Monster Variables
	public float Health;
	public float Timer;
	public bool onLight;
    public float speed;
	public bool isAlerted = false;
    //Monster Componenet
	public Rigidbody2D RBody;
    //Player GameObject & Components
    public GameObject player;
    public Transform target;

	// Use this for initialization
	public virtual void Start ()
	{
		RBody = this.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	/*
	public virtual void Update () 
	{
		if(onLight)
		{
			Health -= 1;
		}
		
		if (Health <= 0)
		{
			Destroy(this.gameObject);
		}
		
		
		if (Timer >= 2f) 
		{
			RBody.velocity = new Vector2 (Random.Range (-1, 2), Random.Range (-1, 2));
			Timer = 0;
		} 
		else 
		{
			Timer += Time.deltaTime;
		}

	}
    */


	void OnTriggerEnter2D(Collider2D coll)
	{
		onLight = true;
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		onLight = false;
	}
}
