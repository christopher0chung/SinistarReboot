using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAction : MonoBehaviour, IMappable {

    private Rigidbody myRB;
    public GameObject bullet;

    public GameObject target;
    private Vector3 heading;
    private float lookDir;

    public float maxRange;
    public float minRange;
    public float speedBase;
    public float speedBoost;

    private Vector3 momentumApplied;
    private Vector3 momentumContributed;

    private bool itsACrystal;
    private GameObject myIcon;


    void Start ()
    {
        myRB = GetComponent<Rigidbody>();
        gameObject.tag = "Mob";
        InvokeRepeating("FireAtAsteroid", Random.Range(4.0f, 10f), 1.2f);
        SpawnIcon();
    }

    public void SpawnIcon()
    {
        myIcon = (GameObject)Instantiate(Resources.Load("MobMM"), Vector3.zero, Quaternion.Euler(90, 0, 0), GameObject.Find("MiniMap").transform);
        myIcon.GetComponent<MiniMapIcon>().TrackMe(transform);
    }
    public void DeleteIcon()
    {
        Destroy(myIcon);
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (target.gameObject.tag == "Crystal")
            {
                CalcHeadingToCrystal();
                itsACrystal = true;
            }
            else if (target.gameObject.tag == "Asteroid")
            {
                CalcHeadingToAsteroid();
                itsACrystal = false;
            }
            Vector3 delta = target.transform.position - transform.position;
            lookDir = Mathf.Lerp(lookDir, (Mathf.Atan2(-delta.z, delta.x) * Mathf.Rad2Deg), .12f);
            transform.rotation = Quaternion.Euler(0, lookDir, 0);
        }

        ApplyThruster();
        myRB.velocity = Vector3.zero;
        momentumApplied = Vector3.Lerp(momentumApplied, momentumContributed, .03f);
        myRB.MovePosition(transform.position + momentumApplied);
    }

    public void SetTgt (GameObject tgt)
    {
        //Debug.Log("Tgt set");
        target = tgt;
    }

    private void CalcHeadingToCrystal()
    {
        if (target != null)
        {
            Vector3 bearing = Vector3.Normalize(target.transform.position - transform.position);
            heading = bearing;
        }
    }

    private void CalcHeadingToAsteroid ()
    {
        if (target != null)
        {
            float rangeToTgt = Vector3.Distance(target.transform.position, transform.position);
            Vector3 bearing = Vector3.Normalize(target.transform.position - transform.position);

            float headingSlider = 1 - ((rangeToTgt - minRange) / (maxRange - minRange));
            headingSlider = Mathf.Clamp(headingSlider, 0, 0.7f);

            heading = Vector3.Lerp(bearing, Vector3.Cross(bearing, Vector3.up), headingSlider);
            Debug.DrawLine(transform.position, transform.position + heading * 20);
        }
    }

    private void ApplyThruster()
    {
        if (target != null)
        {
            if (itsACrystal)
                momentumContributed = heading * (speedBase + speedBoost);
            else
                momentumContributed = heading * (speedBase);
        }
    }

    private void FireAtAsteroid()
    {
        if (!itsACrystal)
            Instantiate(bullet, transform.position + transform.right * 7, transform.rotation);
    }
}
