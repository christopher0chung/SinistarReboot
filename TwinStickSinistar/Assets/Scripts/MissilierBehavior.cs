using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilierBehavior : MonoBehaviour, IBaddyBehavior, IMappable{

    private Rigidbody myRB;

    public GameObject target;
    private Vector3 heading;
    private float lookDir;

    public float speedBase;
    public float speedBoost;

    public float fireRange;

    private Vector3 momentumApplied;
    private Vector3 momentumContributed;

    private GameObject myIcon;

    private IRadar myRadar;

    private float timer;
    public float nextSpotTime;
    public Vector3 searchLoc;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        gameObject.tag = "Mob";
        SpawnIcon();
        myRadar = GetComponent<IRadar>();
        timer = 14;
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
        CalcHeading(target);

        ApplyThruster();
        myRB.velocity = Vector3.zero;
        momentumApplied = Vector3.Lerp(momentumApplied, momentumContributed, .03f);
        //Debug.Log(momentumApplied);

        myRB.MovePosition(transform.position + momentumApplied);

        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= fireRange)
        {
            FireAtTgt();
        }
    }

    // Called by RadarMiner
    public void SetTgt(GameObject tgt)
    {
        //Debug.Log("Tgt set");
        target = tgt;
    }

    // Called based on RadarMiner return
    public void CalcHeading(GameObject tgt)
    {
        if (tgt != null)
        {
            if (tgt.gameObject.tag == "Player")
            {
                Vector3 bearing = Vector3.Normalize(tgt.transform.position - transform.position);
                heading = bearing;
            }

            Vector3 delta = tgt.transform.position - transform.position;
            lookDir = Mathf.Lerp(lookDir, (Mathf.Atan2(-delta.z, delta.x) * Mathf.Rad2Deg), .12f);
            transform.rotation = Quaternion.Euler(0, lookDir, 0);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= nextSpotTime || Vector3.Distance(transform.position, searchLoc) <= 20)
            {
                timer = 0;
                PickARandomSpot();
                Vector3 bearing = Vector3.Normalize(searchLoc - transform.position);
                heading = bearing;
            }
            Vector3 delta = searchLoc - transform.position;
            lookDir = Mathf.Lerp(lookDir, (Mathf.Atan2(-delta.z, delta.x) * Mathf.Rad2Deg), .12f);
            transform.rotation = Quaternion.Euler(0, lookDir, 0);
        }
    }

    // Set based on RadarMiner return
    public void ApplyThruster()
    {
        if (target != null)
        {
            momentumContributed = heading * (speedBase + speedBoost);
        }
        else
        {
            momentumContributed = heading * (speedBase);
        }
    }

    //Set based on RadarMiner return
    public void FireAtTgt()
    {
        target = null;
        Instantiate(Resources.Load("MissilePrefab"), transform.position, Quaternion.identity);
        transform.position = new Vector3(Random.Range(-900, 900), 0, Random.Range(-900, 900));
    }


    private void PickARandomSpot ()
    {
        searchLoc = new Vector3(Random.Range(-800, 800), 0, Random.Range(-800, 800));
    }

    public void CleanKill()
    {
        DeleteIcon();
        Instantiate(Resources.Load("AsteroidExplosion"), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}