using UnityEngine;
using System.Collections;

public class cameraMan : MonoBehaviour {

    public GameObject target;
    public Vector3 pos;
    public bool isFollowing = true;
	public string PlayerObject;

	// Use this for initialization
	void Start () 
    {
        target = GameObject.Find(PlayerObject);
	}
	
	// Update is called once per frame
	void Update ()
    {   
	    if(isFollowing)
        {
            pos = new Vector3(target.transform.position.x, target.transform.position.y+0.91f, -10);
            transform.position = pos;
        }
	}
}
