using UnityEngine;
using System.Collections;

public class ghost : monster {

	// Update is called once per frame
	void Update ()
	{
		if(onLight)
		{
			Health -= 1;
		}
		
		if (Health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
