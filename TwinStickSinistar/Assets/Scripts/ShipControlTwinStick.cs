using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipControlTwinStick : MonoBehaviour, IControllable {

    private float moveAng;
    private float shootAng;

    public float turnRate;
    public float speedBase;
    public float speedBonus;
    private float speedBonusApplied;

    public float heatPerBullet;

    private Vector3 momentumContributed;
    private Vector3 momentumApplied;

    private Transform myPosition;
    private Transform myGuns;

    public GameObject bullet;

    private float holdAng;

    private bool shooting;
    public bool SHOOTING
    {
        get
        {
            return shooting;
        }
        set
        {
            if (value != shooting)
            {
                if (value)
                {
                    reloadTimer = 0;
                    Fire();
                }
                shooting = value;
            }
        }
    }

    private float reloadTimer;
    public float reloadTimeMin;

    private float reloadTimeApplied;

    private GameObject myHeatBar;
    private Text myHeat;
    private float heat;
    private bool overheat;
    private bool OVERHEAT
    {
        get
        {
            return overheat;
        }
        set
        {
            if (value != overheat)
            {
                if (value)
                    heatColor = Color.red;
                else
                    heatColor = Color.blue;
                overheat = value;
            }
        }
    }

    public LookPointBehavior myLPB;

    private Color heatColor;

    private float lastMoveAng;

    private Text countText;
    private int count;
    public int crystalCount
    {
        get
        {
            return count;
        }
        set
        {
            if (value != count)
            {
                countText.text = "Crystal Count: " + value;
                count = value;
            }
        }
    }

    private ParticleSystem [] myPS = new ParticleSystem [3];
    private bool thrusterOn = true;
    private bool THRUSTERON
    {
        get
        {
            return thrusterOn;
        }
        set
        {
            if (value != thrusterOn)
            {
                if (value)
                {
                    for (int i = 0; i < myPS.Length; i++)
                    {
                        myPS[i].Play();
                    }
                }
                else
                {
                    for (int i = 0; i < myPS.Length; i++)
                    {
                        myPS[i].Stop();
                    }
                }
                thrusterOn = value;
            }
        }
    }



	// Use this for initialization
	void Start () {
        myPosition = transform;
        myGuns = transform.Find("ShipShoot");
        myHeat = GameObject.Find("Heat").GetComponent<Text>();
        heat = 100;
        myLPB = GetComponentInChildren<LookPointBehavior>();
        myHeatBar = GameObject.Find("HeatBar");
        countText = GameObject.Find("CrystalCount").GetComponent<Text>();
        for (int i = 0; i < myPS.Length; i++)
        {
            myPS[i] = transform.Find("Thruster").GetChild(i).GetComponent<ParticleSystem>();
        }
        THRUSTERON = false;
	}

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (SHOOTING && !OVERHEAT)
        {
            if (reloadTimer >= reloadTimeApplied)
            {
                reloadTimer = 0;
                Fire();
            }
        }

        if (heat >= 100)
        {
            OVERHEAT = true;
        }
        else if (heat == 0)
        {
            OVERHEAT = false;
        }

        heat = Mathf.MoveTowards(heat, 0, Time.deltaTime * (10 + 20.0f * (1 - (heat/100))));
        myHeat.text = ((int)heat).ToString();
        myHeat.color = heatColor;

        myHeatBar.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(5.5f, 1, 1), heat/100);
        if (OVERHEAT)
        {
            myHeatBar.GetComponent<SpriteRenderer>().color = new Color(1, .5f, .5f, .5f);
        }
        else
        {
            myHeatBar.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(.5f, .5f, 1, .5f), new Color(1, .5f, .5f, .5f), (heat -  50) / 50);
        }
    }
	
    void FixedUpdate()
    {
        momentumApplied = Vector3.Lerp(momentumApplied, momentumContributed, .03f);
        myLPB.LookPtVal(momentumApplied * 20);
        myPosition.position += momentumApplied;
    }

    public void LeftStick(float upDown, float leftRight)
    {
        if (Mathf.Abs(Mathf.Sqrt(upDown * upDown + leftRight * leftRight)) > .15f)
        {
            lastMoveAng = Mathf.Atan2(-upDown, leftRight) * Mathf.Rad2Deg;
            myPosition.rotation = Quaternion.Euler(0, lastMoveAng, 0);
            momentumContributed = new Vector3(leftRight, 0, upDown) * (speedBase + speedBonusApplied);
            THRUSTERON = true;
        }
        else
        {
            myPosition.rotation = Quaternion.Euler(0, lastMoveAng, 0);
            momentumContributed = Vector3.zero;
            THRUSTERON = false;
        }
    }

    public void RightStick(float upDown, float leftRight)
    {
        if (Mathf.Abs(Mathf.Sqrt(upDown * upDown + leftRight * leftRight)) > .15f)
        {
            holdAng = (Mathf.Atan2(-upDown, leftRight) * Mathf.Rad2Deg);
        }
        if (Mathf.Abs(Mathf.Sqrt(upDown * upDown + leftRight * leftRight)) > .25f && !OVERHEAT)
        {
            myGuns.rotation = Quaternion.Euler(0, holdAng, 0);
            SHOOTING = true;
            reloadTimeApplied = Mathf.Lerp(1, reloadTimeMin, Mathf.Abs(Mathf.Sqrt(upDown * upDown + leftRight * leftRight)));
        }
        else
        {
            myGuns.rotation = Quaternion.Euler(0, holdAng, 0);
            SHOOTING = false;
        }
    }

    private void Fire()
    {
        GameObject myBullet = (GameObject)Instantiate(bullet, myGuns.position + myGuns.right * 3, myGuns.rotation);
        myBullet.GetComponent<bulletBehavior>().InheritMomentum(momentumApplied);
        heat += heatPerBullet;
    }
}
