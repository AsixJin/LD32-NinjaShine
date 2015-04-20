using UnityEngine;
using System.Collections;

public class skull : monster {

	void Update () 
	{
        if (onLight)
        {
            Health -= 1;
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(onLight)
        {
            PRBody = player.GetComponent<Rigidbody2D>();
            RBody.velocity = PRBody.velocity*2;
        }
        else
        {
            PRBody = null;
            if (!isAlerted)
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
            else if (isAlerted)
            {
                target = player.GetComponent<Transform>();
                this.transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            }
        }
	   
        if(!ninjaGirl.theLight.activeSelf)
        {
            onLight = false;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.transform.tag == "player")
        {
            ninjaGirl.shortage = true;
        }
    }
}
