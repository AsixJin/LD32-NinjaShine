using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class manger : MonoBehaviour {

    private string start = "Submit";
    private float Timer;
    public Text display;
    public List<bool> Generators;
    public List<GameObject> enemies;

	// Use this for initialization
	void Start () 
    {
	    if(Application.loadedLevel == 0)
        {
            Screen.SetResolution(510, 459, false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
       

        if(Application.loadedLevel == 0)
        {
            if (Input.GetButtonDown(start))
            {
                Application.LoadLevel("Floor1");
            }
        }
        else if(Application.loadedLevel == 1)
        {
            if (!Generators[0] && !Generators[1] && !Generators[2])
            {
                Generators[3] = false;
            }

            if (Generators[3] || enemies.Count != 0)
            {
                Timer += Time.deltaTime;
                display.text = Timer.ToString("F2");
            }
            else if (!Generators[3] && enemies.Count == 0)
            {
                if (Input.GetButtonDown(start))
                {
                    Application.LoadLevel("title");
                }
            }
        }
	    
	}
}
