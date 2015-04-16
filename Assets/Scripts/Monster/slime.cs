using UnityEngine;
using System.Collections;

public class slime : monster {

	// Update is called once per frame
	public override void Update () 
    {
        base.Update();
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

}
