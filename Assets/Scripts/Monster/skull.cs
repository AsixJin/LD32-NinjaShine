using UnityEngine;
using System.Collections;

public class skull : monster {

	void Update () 
	{
	    if(!isAlerted)
        {
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
        else if(isAlerted)
        {
            target = player.GetComponent<Transform>();
            this.transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
	}
}
