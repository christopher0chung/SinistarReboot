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

	// Use this for initialization
	void Start () {
        myPosition = transform;
        myGuns = transform.Find("ShipShoot");
        myHeat = GameObject.Find("Heat").GetComponent<Text>();
        heat = 100;
        myLPB = GetComponentInChildren<LookPointBehavior>();
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
        }
        else
        {
            myPosition.rotation = Quaternion.Euler(0, lastMoveAng, 0);
            momentumContributed = Vector3.zero;
        }
    }

    public void RightStick(float upDown, float leftRight)
    {
        if (Mathf.Abs(Mathf.Sqrt(upDown * upDown + leftRight * leftRight)) > .25f && !OVERHEAT)
        {
            holdAng = (Mathf.Atan2(-upDown, leftRight) * Mathf.Rad2Deg);
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
        heat += 9;
    }
}
