using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ghost : monster {

    GameObject floorlist;
    public List<Transform> Floors = new List<Transform>();

    public override void Start()
    {
        base.Start();
        floorlist = GameObject.Find("_Floor");
        foreach (Transform x in floorlist.GetComponentsInChildren<Transform>())
        {
            Floors.Add(x);   
        }
    }

    // Update is called once per frame
	void Update ()
	{      
		if(onLight)
		{
			Health -= 1;
            this.transform.position = Floors[Random.Range(0, Floors.Count+1)].position;
		}
		
		if (Health <= 0)
		{
			Destroy(this.gameObject);
		}

        if (Timer >= 2f)
        {
            RBody.velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            Timer = 0;
        }
        else
        {
            Timer += Time.deltaTime;
        }
	}
}
