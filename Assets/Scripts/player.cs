using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    //Player Component
    public Rigidbody2D RBody;
	private Animator Anim;
    public GameObject theLight;
    private GameObject childBright;
    private Light lightComp;
	private SpriteRenderer Light;
	private Transform LightTrans;
    //For Player Control
    public float speed;
    private string HAsix = "Horizontal";
    public float HRaw;
    private string VAsix = "Vertical";
    public float VRaw;
    private string LightSwitch = "Fire1";
	//Player Variables
    //Light Variable
    private float BTimer;
    public float energyRate = 0.01f;
    public bool isOn = false;
    public bool shortage = false;
    public int shortCount = 0;
	public int direction;
    public float BeamLength = 1;
    public float BeamWidth = 1;
    public float FlashEnergy = 0.75f;


    //Unity Methods
	void Start () 
    {
        RBody = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
        theLight = GameObject.Find("Light");
        childBright = GameObject.Find("childBright");
        lightComp = childBright.GetComponent<Light>();
        theLight.SetActive(false);
		Light = theLight.GetComponent<SpriteRenderer>();
		LightTrans = theLight.GetComponent<Transform>();
	}
	
	void Update () 
    {
        //Controls the Light Size
        LightTrans.localScale = new Vector3(BeamLength, BeamWidth, 1);
        lightComp.intensity = FlashEnergy*10;
		//Controls the Light Power
        if(Input.GetButtonDown(LightSwitch))
        {
            FlashSwitch();
        }

        if(!isOn)
        {
            FlashEnergy += 0.0001f;
        }

        if(FlashEnergy <= 0)
        {
            FlashEnergy = 0;
            isOn = false;
        }
        else if(FlashEnergy >= 0.80f)
        {
            FlashEnergy = 0.80f;
        }
                
		//Controls player movement
        HRaw = Input.GetAxisRaw(HAsix);
        VRaw = Input.GetAxisRaw(VAsix);
        RBody.velocity = new Vector2(HRaw*speed, VRaw*speed);

		//Ensures that the correct animations is being played
		//in the right direction
		if (HRaw == 0 && VRaw == -1) 
		{
			//South
			direction = 0;
			Anim.SetInteger ("Dir", direction);
            LightTrans.eulerAngles = new Vector3(0, 0, 270);
		} 
		else if (HRaw == -1 && VRaw == 0)
		{
			//West
			direction = 1;
			Anim.SetInteger ("Dir", direction);
            LightTrans.eulerAngles = new Vector3(0, 0, 180);
		}
		else if(HRaw == 0 && VRaw == 1)
		{
			//North
			direction = 2;
			Anim.SetInteger ("Dir", direction);
            LightTrans.eulerAngles = new Vector3(0, 0, 90);
		}
		else if(HRaw == 1 && VRaw == 0)
		{
			//East
			direction = 3;
			Anim.SetInteger ("Dir", direction);
            LightTrans.eulerAngles = new Vector3(0, 0, 0);
		}

     //End of Update Method//   
	}

    void FixedUpdate()
    {
        //Time Related Light Control
        Light.color = new Color(Light.color.r, Light.color.g, Light.color.b, FlashEnergy);
        if(isOn)
        {   
            if(!shortage)
            {
                if (BTimer >= 2)
                {
                    FlashEnergy -= energyRate;
                    BTimer = 0;
                }
                else
                {
                    BTimer += Time.deltaTime;
                }
            }
            else
            {
                if (BTimer >= 0.5f)
                {
                    FlashSwitch();
                    BTimer = 0;
                    shortCount += 1;
                }
                else
                {
                    BTimer += Time.deltaTime;
                }
            }
            
        }

        if(shortCount == 6)
        {
            shortage = false;
            shortCount = 0;
        }
    }

    //Method to switch Light on and off
    public void FlashSwitch()
    {
        if(isOn)
        {
            theLight.SetActive(false);
            isOn = false;        
        }
        else if(!isOn && FlashEnergy > 0)
        {
            theLight.SetActive(true);
            isOn = true;
        }
    }
}
