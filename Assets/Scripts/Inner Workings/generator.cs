using UnityEngine;
using System.Collections;

public class generator : MonoBehaviour {

    //Monster Prefabs for spawning
    public GameObject slime; //0
    public GameObject skull; //1
    public GameObject ghost; //2
    //Spawning variables
    private float Timer = 10f;
    private int index; //Take some cues from work
    public int slimeCount = 5;
    public int skullCount = 1;
    public int ghostCount = 1;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (slimeCount == 0 && skullCount == 0 && ghostCount == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (Timer >= 10f)
            {
                index = Random.Range(0, 3);
                if (index == 0)
                {
                    if (slimeCount != 0)
                    {
                        Instantiate(slime, this.transform.position, Quaternion.identity);
                        slimeCount -= 1;
                        Timer = 0;
                    }
                    else
                    {
                        index = Random.Range(0, 3);
                    }
                }
                else if (index == 1)
                {
                    if (skullCount != 0)
                    {
                        Instantiate(skull, this.transform.position, Quaternion.identity);
                        skullCount -= 1;
                        Timer = 0;
                    }
                    else
                    {
                        index = Random.Range(0, 3);
                    }
                }
                else if (index == 2)
                {
                    if (ghostCount != 0)
                    {
                        Instantiate(ghost, this.transform.position, Quaternion.identity);
                        ghostCount -= 1;
                        Timer = 0;
                    }
                    else
                    {
                        index = Random.Range(0, 3);
                    }
                }
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }
      }
	    
}
