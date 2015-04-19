using UnityEngine;
using System.Collections;

public class overlapTrans : MonoBehaviour {

    public float trans = 0.6f;
    private SpriteRenderer render;

	// Use this for initialization
	void Start () 
    {
        render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(trans >= 1)
		{
			trans = 1;
		}
		else if(trans <= 0)
		{
			trans = 0;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            render.color = new Color(render.color.r, render.color.g, render.color.b, trans);
        }      
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.transform.tag == "player")
        {
            render.color = new Color(render.color.r, render.color.g, render.color.b, 1);
        }      
    }
}

